using searchworks.client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchworks.client.DAL
{
    interface IOrgTenantRepository : IDisposable
    {
        IEnumerable<orgtenant> GetOrgTenants(string aspuserid);
        orgtenant GetOrgTenantByID(int orgtenantid);
        void InsertOrgTenant(orgtenant vorgtenant);
        void DeleteOrgTenant(int orgtenantID);
        void Updateorgtenant(orgtenant vorgtenant);
        void Save();
    }
}
