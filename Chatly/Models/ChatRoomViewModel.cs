using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatly.Models
{
    public class ChatRoomViewModel
    {
        public string UserName { get; set; }
        [Display(Name = "Room Code")]
        public int CodeId { get; set; }
        public IEnumerable<CodeViewModel> Codes { get; set; }
    }
}