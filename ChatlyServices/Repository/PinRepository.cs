using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatlyServices
{
    public class PinRepository : IPinRepository
    {
          #region Member Variables
      private ChatlyEntities context = null;
      #endregion

      #region Constructor

      public PinRepository()
      {
          context = new ChatlyEntities(); //Wrap and instantiate the ObjectContext
      }

      #endregion
      #region Messages

      public Pins GetPin(int pinId)
      {

         //Apply LINQ get the specific bookmark based in id
          var msg = from b in context.Pins
                    where b.Id == pinId
                         select b;
          return msg.FirstOrDefault();

      }

      public IEnumerable<Pins> GetPinList()
      {
          return context.Pins.ToList();
      }

      public void AddPin(Pins pin)
      {
          context.Pins.Add(pin);
          context.SaveChanges(); //Persist changes to DB
      }

      public void UpdatePin(Pins pin)
      {
          Pins existingPin = GetPin(pin.Id);
          context.Entry(existingPin).CurrentValues.SetValues(pin);
          context.SaveChanges(); //Persist changes to DB
      }

      public void DeletePin(Pins pin)
      {
          Pins existingPin = GetPin(pin.Id);
          context.Pins.Remove(existingPin);
          context.SaveChanges(); //Persist changes to DB
      }

      #endregion
    }
}