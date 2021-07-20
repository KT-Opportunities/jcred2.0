using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using searchworks.client.Models;

namespace searchworks.client.Helpers
{
    public class JCredHelper
    {
        IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);

        //singleton
        public static JCredHelper Instance { get; protected set; } = new JCredHelper();


        public JCredHelper()
        {

        }

        public int GetUserTenantID(string strAspUserID)
        {
            int tenantID = -1;

            try
            {
                var tenantusermap = db.Query<orgunitusermap>("Select * From orgunitusermap where aspiden_uid='" + strAspUserID + "'").FirstOrDefault();
                tenantID = Convert.ToInt32(tenantusermap.orgtenantid);
            }
            catch (Exception err)
            {
                tenantID = -1;
            }

            return tenantID;
        }

    }
}