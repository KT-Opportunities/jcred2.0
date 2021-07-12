using searchworks.client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchworks.client.DAL
{
    interface IOrgUnitRepository : IDisposable
    {
        IEnumerable<orgunit> GetOrgUnits(int orgtenantID);
        orgunit GetOrgUnitByID(int orgunitID);
        void InsertOrgUnit(orgunit vorgunit , int parent_orgunitid);
        void DeleteOrgUnit(int orgunitID);
        void UpdateOrgUnit(orgunit vorgunit);
        void Save();
    }
}
