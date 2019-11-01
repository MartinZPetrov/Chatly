using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatlyServices
{
    public class MessagesRepository : IMessageRepository
    {

      #region Member Variables
      private ChatlyEntities entity = null;
      #endregion

      #region Constructor

      public MessagesRepository()
      {
          entity = new ChatlyEntities(); //Wrap and instantiate the ObjectContext
      }

      #endregion
      #region Messages

      public Messages GetMessage(int messageID)
      {

         //Apply LINQ get the specific bookmark based in id
          var msg = from b in entity.Messages
                         where b.Id == messageID
                         select b;
          return msg.FirstOrDefault();

      }

      public IEnumerable<Messages> GetMessagesList()
      {
          return entity.Messages.ToList();
      }

      public void AddMessage(Messages message)
      {
          entity.Messages.Add(message);
          entity.SaveChanges(); //Persist changes to DB
      }

      public void UpdateMessage(Messages message)
      {
          Messages existingMessage = GetMessage(message.Id);
          entity.Entry(existingMessage).CurrentValues.SetValues(message);
          entity.SaveChanges(); //Persist changes to DB
      }

      public void DeleteMessage(Messages message)
      {
          Messages existingMessages = GetMessage(message.Id);
          entity.Messages.Remove(message);
          entity.SaveChanges(); //Persist changes to DB
      }

      #endregion

     #region 

     #endregion
    }
}