﻿using ChatlyServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ChatlyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DataService : IDataService
    {
        
        
        private IMessageRepository messagesRepository = new MessagesRepository();
        private ICodeRepository codeRepository = new CodeRepository();
        private IUserRepository userRepositry = new UserRepository();
 
        #region Messages
        public Messages GetMessage(int bookmarkId)
        {
            return messagesRepository.GetMessage(bookmarkId);
        }

        public IEnumerable<Messages> GetMessagesList()
        {
            return messagesRepository.GetMessagesList();
        }

        public void AddMessage(Messages message)
        {
            messagesRepository.AddMessage(message);
        }

        public void UpdateMessage(Messages message)
        {
            messagesRepository.UpdateMessage(message);
        }

        public void DeleteMessage(Messages message)
        {
            messagesRepository.DeleteMessage(message);
        }
        #endregion

        #region Codes
        public Codes GetCode(int codeId)
        {
            return codeRepository.GetCode(codeId);
        }

        public IEnumerable<Codes> GetCodesList()
        {
            return codeRepository.GetCodeList();
        }

        public void AddCode(Codes code)
        {
            codeRepository.AddCode(code);
        }

        public void UpdateCode(Codes code)
        {
            codeRepository.UpdateCode(code);
        }

        public void DeleteCode(Codes code)
        {
            codeRepository.DeleteCode(code);
        }

        public IEnumerable<AspNetUsers> GetUserList()
        {
            return userRepositry.GetUsersList();
        }
        #endregion
    }
}
