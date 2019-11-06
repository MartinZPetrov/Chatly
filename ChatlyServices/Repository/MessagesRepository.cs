using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ChatlyServices
{
    public class MessagesRepository : IMessageRepository
    {

      #region Member Variables
      private ChatlyEntities context = null;
      #endregion

      #region Constructor

      public MessagesRepository()
      {
          context = new ChatlyEntities(); //Wrap and instantiate the ObjectContext
      }

      #endregion
      #region Messages

      public Messages GetMessage(int messageID)
      {

         //Apply LINQ get the specific bookmark based in id
          var msg = from b in context.Messages
                         where b.Id == messageID
                         select b;
          return msg.FirstOrDefault();

      }

      public IEnumerable<Messages> GetMessagesList()
      {
          return context.Messages.Include(e=>e.Users).Include(e=>e.Codes).ToList();
      }

      public void AddMessage(Messages message)
      {
          context.Messages.Add(message);
          context.SaveChanges(); //Persist changes to DB
      }

      public void UpdateMessage(Messages message)
      {
          Messages existingMessage = GetMessage(message.Id);
          context.Entry(existingMessage).CurrentValues.SetValues(message);
          context.SaveChanges(); //Persist changes to DB
      }

      public void DeleteMessage(Messages message)
      {
          Messages existingMessages = GetMessage(message.Id);
          context.Entry(existingMessages).State = EntityState.Deleted;
          //context.Messages.Remove(message);
          context.SaveChanges(); //Persist changes to DB
      }

      #endregion
    }
}