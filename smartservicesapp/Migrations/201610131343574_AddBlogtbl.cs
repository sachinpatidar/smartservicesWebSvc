namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogtbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddBlogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        FileID = c.Int(nullable: false),
                        textContent = c.String(unicode: false, storeType: "text"),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId);
            
            AddColumn("dbo.Category", "AddBlogs_BlogId", c => c.Int());
            AddColumn("dbo.UserRegister", "AddBlog_BlogId", c => c.Int());
            CreateIndex("dbo.Category", "AddBlogs_BlogId");
            CreateIndex("dbo.UserRegister", "AddBlog_BlogId");
            AddForeignKey("dbo.Category", "AddBlogs_BlogId", "dbo.AddBlogs", "BlogId");
            AddForeignKey("dbo.UserRegister", "AddBlog_BlogId", "dbo.AddBlogs", "BlogId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRegister", "AddBlog_BlogId", "dbo.AddBlogs");
            DropForeignKey("dbo.Category", "AddBlogs_BlogId", "dbo.AddBlogs");
            DropIndex("dbo.UserRegister", new[] { "AddBlog_BlogId" });
            DropIndex("dbo.Category", new[] { "AddBlogs_BlogId" });
            DropColumn("dbo.UserRegister", "AddBlog_BlogId");
            DropColumn("dbo.Category", "AddBlogs_BlogId");
            DropTable("dbo.AddBlogs");
        }
    }
}
