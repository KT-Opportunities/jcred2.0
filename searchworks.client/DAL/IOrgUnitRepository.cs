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
        int InsertOrgUnit(orgunit vorgunit, int parent_orgunitid);
        int DeleteOrgUnit(int orgunitID);
        int UpdateOrgUnit(orgunit vorgunit);
        void Save();

        //void NewMethod(); NLog
    }
}
