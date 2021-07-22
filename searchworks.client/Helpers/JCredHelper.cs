using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using searchworks.client.Models;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace searchworks.client.Helpers
{
    public class JCredHelper : IDisposable
    {
        private IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);
        private bool disposed = false;

        //singleton
        public static JCredHelper Instance { get; protected set; } = new JCredHelper();

        public JCredHelper()
        {
        }

        public string GetSWAPIHostUrl()
        {
            string api_host = "";
            try
            {
                api_host = Convert.ToString(ConfigurationManager.AppSettings["SWAPIHostUrl"]);
            }
            catch (Exception err)
            {
                throw;
            }

            return api_host;
        }

        public string GetSWAPILoginToken()
        {
            string loginToken = "";

            //get config from settings
            string api_username = "";
            string api_password = "";
            string api_host = "";

            try
            {
                api_username = Convert.ToString(ConfigurationManager.AppSettings["SWAPIUID"]);
                api_password = Convert.ToString(ConfigurationManager.AppSettings["SWAPIPWD"]);
                api_host = Convert.ToString(ConfigurationManager.AppSettings["SWAPIHostUrl"]) + "/auth/login/";
            }
            catch (Exception err)
            {
                //throw;
            }

            var userName = api_username;
            var password = api_password;
            var host = api_host;
            var body_credentials = new
            {
                Username = api_username,
                Password = api_password
            };

            string authBody = "{  \"Username\": \"" + userName + "\",  \"Password\": \"" + password + "\" }";

            var client = new RestClient(host);

            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", authBody, ParameterType.RequestBody);

            try
            {
                IRestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    dynamic respContent = JObject.Parse(response.Content);
                    loginToken = respContent.ResponseMessage;
                }
                else
                {//something went wrong: log the response
                }
            }
            catch (Exception err)
            {
                //error
                //throw;
            }

            return loginToken;
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

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //dispos any object that got created //_context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}