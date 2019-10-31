﻿using System;
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

        // TODO: Add your service operations here
    }


  
}
