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
        IEnumerable<orgunitusermap> GetOrgUnitUsers(int orgunitID);
        orgunitusermap GetOrgUnitUserByID(int orgunitusermapID);
        void InsertOrgUnitUser(orgunit vorgunit, string aspneruserid);
        void DeleteOrgUnitUser(int orgunitusermapID);
        void UpdateOrgUnitUser(orgunitusermap vorgunitusermap);
        void Save();
    }
}
