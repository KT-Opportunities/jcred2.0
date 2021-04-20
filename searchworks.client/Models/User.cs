using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace searchworks.client.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullname { get; set; } //Why? public int? fullname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string code { get; set; }
    }
}