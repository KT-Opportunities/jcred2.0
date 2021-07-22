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

        public orgtenant Emptycompany { get; set; }

        public List<orgunit> orgunits { get; set; }

        public orgcategory Category { get; set; }

        public List<User> users { get; set; }

        public orgunit Currentorgunit { get; set; }

        public orgunit Addorgunit { get; set; }

        public orgregion orgregion { get; set; }

        public UserManagementViewModel()
        {
        }

        public void SetCurrentOrgUnit(orgunit vorgunit)
        {
            this.Currentorgunit = vorgunit;
        }

        public UserManagementViewModel(int intorgtenant)
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                try
                {
                    this.Company = db.Query<orgtenant>("Select * From orgtenant where orgtenantid=" + intorgtenant).FirstOrDefault();
                }
                catch (Exception err)
                {
                    this.Company = null;
                    //TODO: log the error
                }

                try
                {
                    this.orgunits = db.Query<orgunit>("Select * From orgunit where orgtenantid=" + this.Company.orgtenantid).ToList();
                }
                catch (Exception err)
                {
                    this.orgunits = null;
                    //TODO: log the error
                }

                try
                {
                    this.Category = db.Query<orgcategory>("Select * From orgcategory where orgcategoryid=" + this.Company.orgcategoryid).FirstOrDefault();
                }
                catch (Exception err)
                {
                    this.Category = null;
                    //TODO: log the error
                }

                try
                {
                    //a company can have more than one branch
                    this.Currentorgunit = db.Query<orgunit>("Select * From orgunit where orgtenantid=" + this.Company.orgtenantid).FirstOrDefault();
                }
                catch (Exception err)
                {
                    this.Currentorgunit = null;
                    //TODO: log the error
                }

                try
                {
                    this.orgregion = db.Query<orgregion>("Select * From orgregion where orgregionid=" + this.Currentorgunit.regionid).FirstOrDefault();
                }
                catch (Exception err)
                {
                    this.orgregion = null;
                    //TODO: log the error
                }


                try
                {
                    string query = "Select * From user where id in (select userid from orgunitusermap where orgtenantid = " + Convert.ToString(this.Company.orgtenantid) + " )";
                    this.users = db.Query<User>(query).ToList();
                }
                catch (Exception err)
                {
                    this.users = null;
                    //TODO: log the error

                }

            }
        }
    }
}