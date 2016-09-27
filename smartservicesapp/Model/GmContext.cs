namespace gmcscoServices.Model
{
    using System.Data.Entity;
    public class GmContext:DbContext
    {
        public GmContext() : base("name=DefaultConnection") {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GmContext, gmcscoServices.Migrations.Configuration>("DefaultConnection"));

        }


        public virtual DbSet<ContactMessage> ContactMessage { get; set; }
        public virtual DbSet<Subscribe> Subscribe  { get; set; }
        //     public virtual DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}