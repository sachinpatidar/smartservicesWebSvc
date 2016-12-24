namespace smartservicesapp.Model
{
    using System.Data.Entity;
    public class GmContext : DbContext
    {
        public GmContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GmContext, smartservicesapp.Migrations.Configuration>("DefaultConnection"));

        }


        public virtual DbSet<Model.UserRegister> UserRegister { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<PrivacyType> PrivacyType { get; set; }
        public virtual DbSet<AddBlog> AddBlog { get; set; }
        public virtual DbSet<BlogDocument> BlogDocument { get; set; }
        public virtual DbSet<FileSetting> FileSetting { get; set; }
        public virtual DbSet<BlogComment> BlogComment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}