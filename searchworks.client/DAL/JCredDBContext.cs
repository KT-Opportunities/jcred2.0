using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using searchworks.client.Models;

namespace searchworks.client.DAL
{
    public partial class JCredDBContext : DbContext
    {
        public JCredDBContext()
            : base("name=JCredDBContextEntities")
        {

        }


        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<orgcategory> orgcategories { get; set; }
        public virtual DbSet<orgregion> orgregions { get; set; }
        public virtual DbSet<orgtenant> orgtenants { get; set; }
        public virtual DbSet<orgtenantpriv> orgtenantprivs { get; set; }
        public virtual DbSet<orgunit> orgunits { get; set; }
        public virtual DbSet<orgunitprivmap> orgunitprivmaps { get; set; }
        public virtual DbSet<orgunituserprivmap> orgunituserprivmaps { get; set; }
        public virtual DbSet<aspnetpasshashhistory> aspnetpasshashhistories { get; set; }
        public virtual DbSet<aspnetuser> aspnetusers { get; set; }
    }
}