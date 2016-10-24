namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBlog_updateRegisteration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegister", "FileId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRegister", "FileId");
        }
    }
}
