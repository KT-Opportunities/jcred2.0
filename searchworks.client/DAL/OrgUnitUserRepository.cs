using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Configuration;
using searchworks.client.Models;
using searchworks.client.Credit;
using Dapper;
using System.Data;
using searchworks.client.DAL;

namespace searchworks.client.DAL
{
    public class OrgUnitUserRepository : IOrgUnitUserRepository
    {
        private bool disposed = false;
        private JCredDBContext _context;
        private IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);

        public OrgUnitUserRepository(JCredDBContext context)
        {
            this._context = context;
        }


        public IEnumerable<OrgUnitUser> GetOrgUnitUsers(int orgunitID)
        {
            throw new NotImplementedException();
        }

        public OrgUnitUser GetOrgUnitUserByID(int orgunitusermapID)
        {
            throw new NotImplementedException();
        }



        public void DeleteOrgUnitUser(int orgunitusermapID)
        {
            throw new NotImplementedException();
        }

        


        
        public void InsertOrgUnitUser(OrgUnitUser vOrgUnitUser)
        {

            //1 Create ASP login using the context.
            //2 DB create
            //throw new NotImplementedException();
        }

        public void UpdateOrgUnitUser(OrgUnitUser vOrgUnitUserp)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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