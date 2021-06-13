namespace searchworks.client.Models
{
    using System.Data.Entity;

    public partial class dbChecks : DbContext
    {
        public dbChecks()
            : base("name=dbChecks")
        {
        }

        public virtual DbSet<check> Checks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<check>()
                .Property(e => e.search_date);

            modelBuilder.Entity<check>()
                .Property(e => e.check_id);

            modelBuilder.Entity<check>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.maiden_name)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.IDNum)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.passportNum)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.DOB);

            modelBuilder.Entity<check>()
                .Property(e => e.mobile);

            modelBuilder.Entity<check>()
                .Property(e => e.Num_search);

            modelBuilder.Entity<check>()
                .Property(e => e.reason)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.consent_Form)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.user_id);

            modelBuilder.Entity<check>()
                .Property(e => e.user_email)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.complete_date)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.checks)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.results)
                .IsUnicode(false);

            modelBuilder.Entity<check>()
                .Property(e => e.summary)
                .IsUnicode(false);
        }
    }
}