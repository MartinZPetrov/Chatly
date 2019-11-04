using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatly.Models
{
    public class CodeViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Code")]
        public string Code { get; set; }

    }
}