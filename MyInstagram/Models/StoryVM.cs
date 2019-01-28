using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyInstagram.Models
{
    public class StoryVM
    {
        public HttpPostedFileBase file { get; set; }
        public string StoryComment { get; set; }
    }
}