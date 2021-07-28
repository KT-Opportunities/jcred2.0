using searchworks.client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchworks.client.DAL
{
    interface IOrgUnitUserRepository : IDisposable
    {
        IEnumerable<OrgUnitUser> GetOrgUnitUsers(int orgunitID);
        OrgUnitUser GetOrgUnitUserByID(int orgunitusermapID);

        void InsertOrgUnitUser(OrgUnitUser vOrgUnitUser);
        void UpdateOrgUnitUser(OrgUnitUser vOrgUnitUser);
        void DeleteOrgUnitUser(int orgunitusermapID);
        

        void Save();
    }
}
