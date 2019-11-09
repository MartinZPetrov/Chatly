using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ChatlyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataService
    {
        //MESSAGES
        [OperationContract]
        Messages GetMessage(int bookmarkId);
        [OperationContract]
        IEnumerable<Messages> GetMessagesList();
        [OperationContract]
        void AddMessage(Messages message);
        [OperationContract]
        void UpdateMessage(Messages message);
        [OperationContract]
        void DeleteMessage(Messages message);
        [OperationContract]
        //PINS
        Codes GetCode(int codeId);
        [OperationContract]
        IEnumerable<Codes> GetCodesList();
        [OperationContract]
        void AddCode(Codes code);
        [OperationContract]
        void UpdateCode(Codes code);
        [OperationContract]
        void DeleteCode(Codes code);
        [OperationContract]
        IEnumerable<AspNetUsers> GetUserList();
    }
}
