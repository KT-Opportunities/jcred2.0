using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace searchworks.client.Models
{
    public class UserManagementViewModel
    {
        public orgtenant Company { get; set; }
        public List<orgunit> orgunits { get; set; }

        public List<User> users { get; set; }
    }
}