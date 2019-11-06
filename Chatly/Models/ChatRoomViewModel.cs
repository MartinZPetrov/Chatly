using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatly.Models
{
    public class ChatRoomViewModel
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string RoomCode { get; set; }

        [Display(Name = "Room Code")]
        public int CodeId { get; set; }
        public CodeViewModel Code { get; set; }
        public IEnumerable<CodeViewModel> Codes { get; set; }

    }
}