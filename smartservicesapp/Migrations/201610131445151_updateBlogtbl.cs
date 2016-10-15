namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBlogtbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "AddBlogs_BlogId", "dbo.AddBlogs");
            DropForeignKey("dbo.UserRegister", "AddBlog_BlogId", "dbo.AddBlogs");
            DropIndex("dbo.Category", new[] { "AddBlogs_BlogId" });
            DropIndex("dbo.UserRegister", new[] { "AddBlog_BlogId" });
            DropColumn("dbo.Category", "AddBlogs_BlogId");
            DropColumn("dbo.UserRegister", "AddBlog_BlogId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRegister", "AddBlog_BlogId", c => c.Int());
            AddColumn("dbo.Category", "AddBlogs_BlogId", c => c.Int());
            CreateIndex("dbo.UserRegister", "AddBlog_BlogId");
            CreateIndex("dbo.Category", "AddBlogs_BlogId");
            AddForeignKey("dbo.UserRegister", "AddBlog_BlogId", "dbo.AddBlogs", "BlogId");
            AddForeignKey("dbo.Category", "AddBlogs_BlogId", "dbo.AddBlogs", "BlogId");
        }
    }
}
