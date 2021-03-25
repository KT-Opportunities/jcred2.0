namespace searchworks.client.Models
{
    using System.Data.Entity;

    public partial class checkList : DbContext
    {
        public checkList()
            : base("name=checkList")
        {
        }

        public virtual DbSet<check_list> check_list { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<check_list>()
                .Property(e => e.checks)
                .IsUnicode(false);

            modelBuilder.Entity<check_list>()
                .Property(e => e.detail_attached_file_name)
                .IsUnicode(false);
        }
    }
}