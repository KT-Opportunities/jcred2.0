using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using searchworks.client.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace searchworks.client.DAL
{
    public class OrgTenantRepository : IOrgTenantRepository
    {
        private bool disposed = false;
        private JCredDBContext _context;
        private IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);
        public OrgTenantRepository(JCredDBContext context)
        {
            this._context = context;
        }

        public void DeleteOrgTenant(int orgtenantID)
        {
            throw new NotImplementedException();
        }

       
        public orgtenant GetOrgTenantByID(int orgtenantid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<orgtenant> GetOrgTenants(string aspuserid)
        {
            throw new NotImplementedException();
        }

        public void InsertOrgTenant(orgtenant vorgtenant)
        {
            throw new NotImplementedException();
        }

       

        public void Updateorgtenant(orgtenant vorgtenant)
        {
            throw new NotImplementedException();
        }



        public void Save()
        {
            _context.SaveChanges();
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