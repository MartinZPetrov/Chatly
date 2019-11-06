$(document).ready(function (mpwchat) {

    mpwchat.log = mpwchat.log || {};    //Log
    //Log write helper function (txaChat ID hard coded in)
    mpwchat.log.write = function (message) {
        //Create the log message
        if (typeof (message) != typeof ("")) message = "[kb] Invalid Log Message Format!";
        //Append the new log message
        var msg = document.getElementById("txaChat").value;
        msg += message + '\n';
        document.getElementById("txaChat").value = msg;
    }

    var conn = $.hubConnection();   //Hub (server) connection private var 
    var gHub = conn.createHubProxy('chatHub'); //Chat Hub (server) Proxy var
    var joinedChat = false; //Joined chat server flag


    //Bind Connect Button
    $('#btnJoin').click(function () {

        //On Connect
        if (!joinedChat) {
            document.getElementById("txaChat").value = ""; //Reset chat box
            mpwchat.log.write("[InfoServ Chat] Connecting...");
            conn.stop();
            //Start connection
            conn.start().done(function () {
                try {
                    mpwchat.log.write("[InfoServ Chat] Connected to Chat Server");
                    //Connect Request
                    var userName = document.getElementById("txbUserName").value;
                    var select = document.getElementById('ddl1')
                    var roomCode = select.options[select.selectedIndex].text;
                    if (!userName) {
                        mpwchat.log.write("[InfoServ Chat]{Error} Invalid Username");
                    } else {
                        mpwchat.log.write("[InfoServ Chat] Joining as " + userName);
                        mpwchat.log.write("[InfoServ Chat] Enter room : " + roomCode);
                        gHub.invoke('userInformation', userName)
                            .done(function () {
                                //Request Sent
                            })
                            .fail(function (error) {
                                //Request Failed
                                mpwchat.log.write("[InfoServ Chat]{Error} " + error.message);
                                conn.stop();
                                joinedChat = false;
                            });
                    }
                } catch (ex) {
                    mpwchat.log.write("[InfoServ Chat]{Error} " + ex.message);
                    conn.stop();
                    joinedChat = false;
                }
            });

            //On Disconnect
        } else {
            conn.stop();
        }
    });


    //Connect Button
    $('#btnSendOne').click(function () {
        if (joinedChat) {
            var userName = document.getElementById("txbUserName").value;
            var val = document.getElementById("txbMessageOne").value;
            var select = document.getElementById('ddl1')
            var roomCode = select.options[select.selectedIndex].text;
            AddChatMessage(userName, val, roomCode);
            gHub.invoke('messageFromUser', document.getElementById("txbMessageOne").value)
                .done(function () {
                    //Request Sent
                    document.getElementById("txbMessageOne").value = "";
                })
                .fail(function (error) {
                    //Request Failed
                    mpwchat.log.write("[InfoServ Chat]{Error} " + error.message);
                    conn.stop();
                    joinedChat = false;
                });
            //}
        }
    });

    //Connect Button
    $('#btnSendTwo').click(function () {
        if (joinedChat) {
            var userName = document.getElementById("txbUserName").value;
            var val = document.getElementById("txbMessageTwo").value;
            var select = document.getElementById('ddl1')
            var roomCode = select.options[select.selectedIndex].text;
            AddChatMessage(userName, val, roomCode);
            gHub.invoke('messageFromUser', document.getElementById("txbMessageTwo").value)
                .done(function () {
                    //Request Sent
                    document.getElementById("txbMessageTwo").value = "";
                })
                .fail(function (error) {
                    //Request Failed
                    mpwchat.log.write("[InfoServ Chat]{Error} " + error.message);
                    conn.stop();
                    joinedChat = false;
                });
            //}
        }
    });

    //Server message: In response to userInformation
    gHub.on('userInfoResults', function (results) {
        if (results) {
            mpwchat.log.write("[InfoServ Chat] Joined Chat");
            document.getElementById("btnJoin").value = "Disconnect";
        }
        else {
            conn.stop();
        }
        joinedChat = results;
    });

    //Hub event: Disconnected
    conn.disconnected(function () {
        mpwchat.log.write("Disconnected");
        document.getElementById("txaUsers").value = "";
        document.getElementById("btnJoin").value = "Join";
        joinedChat = false;
    });

    //Server message: New user
    gHub.on('newUser', function (user) {
        document.getElementById("txaChat").value += "User '" + user + "' Joined the chat\n";
    });

    //Server message: Connected user list
    gHub.on('userList', function (users, userCount) {
        try {
            var userList = document.getElementById("txaUsers");
            var list = "";
            for (var i = 0; i < userCount; i++) {
                list += users[i];
                list += '\n';
            }
            userList.value = list;
        } catch (ex) {
            mpwchat.log.write("[MPW Chat]{Error} " + ex.message);
        }
    });

    //Server message: User left
    gHub.on('userLeft', function (user) {
        try {
            document.getElementById("txaChat").value += "User '" + user + "' Disconnected \n";
        } catch (ex) {
            mpwchat.log.write("[InfoServ Chat]{Error} " + ex.message);
        }
    });

    //Server message: User message
    gHub.on('messageToUsers', function (username, message) {
        try {
            document.getElementById("txaChat").value += username + ": " + message + '\n';

        } catch (ex) {
            mpwchat.log.write("[InfoServ Chat]{Error} " + ex.message);
        }
    });

    function AddChatMessage(user, message, roomCode) {
        $.ajax({
            type:"POST",
            url: 'AddMessage',
            data: {
                user: user,
                message: message,
                roomCode: roomCode
            }
        })
    }

}(window.mpwchat = window.mpwchat || {}));
