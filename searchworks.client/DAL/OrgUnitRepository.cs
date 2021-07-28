using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using searchworks.client.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using Dapper;

namespace searchworks.client.DAL
{
    public class OrgUnitRepository : IOrgUnitRepository
    {
        private bool disposed = false;
        private JCredDBContext _context;
        private IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);

        public OrgUnitRepository(JCredDBContext context)
        {
            this._context = context;
        }

        public orgunit GetOrgUnitByID(int orgunitID)
        {
            orgunit vorgunit = new orgunit();


            vorgunit = db.Query<orgunit>("Select * From orgunit where orgunitid=" + orgunitID).FirstOrDefault();
            //throw new NotImplementedException();
            return vorgunit;
        }

        public IEnumerable<orgunit> GetOrgUnits(int orgtenantID)
        {
            List<orgunit> lstOrgunits = new List<orgunit>();

            //using EF
            var orgUnitsEF = from s in _context.orgunits
                             where s.orgtenantid == orgtenantID
                             select s;
            lstOrgunits = orgUnitsEF.ToList();


            //using Dapper
            var orgTenant = db.Query<orgtenant>("Select * From orgtenant where orgtenantid=" + orgtenantID).FirstOrDefault();
            var orgUnitsDapperList = db.Query<orgunit>("Select * From orgunit where orgtenantid=" + orgTenant.orgtenantid).ToList();
            lstOrgunits = orgUnitsDapperList;

            return lstOrgunits;

            //throw new NotImplementedException();
        }

        public int InsertOrgUnit(orgunit vorgunit, int parent_orgunitid)
        {
            //throw new NotImplementedException();
            // use EF
            try
            {
                //_context.orgunits.Add(vorgunit);
                var affectedRows = db.Execute("insert into orgunit(parent_orgunitid,orgtenantid,orgunitname,orgunitcode,regionid,telephone,fax,postal_address,postal_code,physical_address,physical_code,orgunit_regno,orgunit_vatno) values(@parent_orgunitid,@orgtenantid,@orgunitname,@orgunitcode,@regionid,@telephone,@fax,@postal_address,@postal_code,@physical_address,@physical_code,@orgunit_regno,@orgunit_vatno)",
                            vorgunit, null, 60, CommandType.Text);
                Save();
                return affectedRows;
            }
            catch (Exception err)
            {
                return 0;
            }



        }

        public int UpdateOrgUnit(orgunit vorgunit)
        {
            //throw new NotImplementedException();
            try
            {
                //_context.orgunits.up(vorgunit);
                var affectedRows = db.Execute(@"update  orgunit set 
                                                     parent_orgunitid=@parent_orgunitid,
                                                     orgtenantid =@orgtenantid,
                                                     orgunitname =@orgunitname,
                                                     orgunitcode =@orgunitcode,
                                                     regionid =@regionid,
                                                     telephone =@telephone,
                                                     fax =@fax,
                                                     orgunit_vatno=@orgunit_vatno,
                                                     orgunit_regno=@orgunit_regno,
                                                     postal_address =@postal_address,
                                                     postal_code =@postal_code,
                                                     physical_address =@physical_address,
                                                     physical_code =@physical_code
                                                    where orgunitid=@orgunitid",
                           vorgunit, null, 60, CommandType.Text);
                Save();

                return affectedRows;

            }
            catch (Exception err)
            {
                return 0;
            }
        }

        public int DeleteOrgUnit(int orgunitID)
        {
            return 0;
            //throw new NotImplementedException();
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