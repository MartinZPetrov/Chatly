using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ChatlyServices
{
    public interface IMessageRepository
    {
        Messages GetMessage(int messageId);
        IEnumerable<Messages> GetMessagesList();
        void AddMessage(Messages message);
        void UpdateMessage(Messages message);
        void DeleteMessage(Messages message);        
    }
}