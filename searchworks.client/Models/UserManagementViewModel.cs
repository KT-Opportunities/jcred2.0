using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace searchworks.client.Models
{
    public class UserManagementViewModel
    {
        public orgtenant Company { get; set; }
        public List<orgunit> orgunits { get; set; }

        public List<User> users { get; set; }

        public UserManagementViewModel()
        {

        }

        public UserManagementViewModel(int intorgtenant)
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                this.Company = db.Query<orgtenant>("Select * From orgtenant where orgtenantid="+ intorgtenant).FirstOrDefault();
                this.orgunits = db.Query<orgunit>("Select * From orgunit where orgtenantid=" + this.Company.orgtenantid).ToList();
            }
        }
    }
}