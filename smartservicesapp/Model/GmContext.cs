namespace smartservicesapp.Model
{
    using System.Data.Entity;
    public class GmContext:DbContext
    {
        public GmContext() : base("name=DefaultConnection") {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GmContext, smartservicesapp.Migrations.Configuration>("DefaultConnection"));

        }


        public virtual DbSet<UserRegister> UserRegister { get; set; }
        public virtual DbSet<Category> Category { get; set; }
       public virtual DbSet<PrivacyType> PrivacyType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}