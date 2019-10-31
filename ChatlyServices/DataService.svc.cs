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
        private DataRepository dataRepo = new DataRepository();
        public Messages GetMessage(int bookmarkId)
        {
            return dataRepo.GetMessage(bookmarkId);
        }

        public IEnumerable<Messages> GetMessagesList()
        {
            return dataRepo.GetMessagesList();
        }

        public void AddMessage(Messages message)
        {
            dataRepo.AddMessage(message);
        }

        public void UpdateMessage(Messages message)
        {
            dataRepo.UpdateMessage(message);
        }

        public void DeleteMessage(Messages message)
        {
            dataRepo.DeleteMessage(message);
        }
    }
}
