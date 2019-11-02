using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatlyServices
{
    public interface IPinRepository
    {
        Pins GetPin(int messageId);
        IEnumerable<Pins> GetPinList();
        void AddPin(Pins message);
        void UpdatePin(Pins message);
        void DeletePin(Pins message);
    }
}