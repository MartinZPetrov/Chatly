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
        private IPinRepository pinRepository = new PinRepository();
        private IUserRepository userRepository = new UsersRepository();

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

        #region Pin
        public Pins GetPin(int pinId)
        {
            return pinRepository.GetPin(pinId);
        }

        public IEnumerable<Pins> GetPinsList()
        {
            return pinRepository.GetPinList();
        }

        public void AddPin(Pins pin)
        {
            pinRepository.AddPin(pin);
        }

        public void UpdatePin(Pins pin)
        {
            pinRepository.UpdatePin(pin);
        }

        public void DeletePin(Pins pin)
        {
            pinRepository.DeletePin(pin);
        }
        #endregion

        #region Users

        public Users Login(string username, string password)
        {
            return userRepository.Authenticate(username, password);
        }

        public Users Create(Users user, string password)
        {
           return  userRepository.Create(user, password);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }
        public bool UserExists(int userId)
        {
            return userRepository.UserExists(userId);
        }
        public bool Save()
        {
            return userRepository.Save();
        }
        #endregion

    }
}
