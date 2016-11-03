namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUpdatefileInfos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddBlogs", "PrivacyID", c => c.Int(nullable: false));
            AddColumn("dbo.FileSettings", "SourceID", c => c.Int(nullable: false));
            AddColumn("dbo.FileSettings", "FilePath", c => c.String(unicode: false));
            DropColumn("dbo.AddBlogs", "FileID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AddBlogs", "FileID", c => c.Int(nullable: false));
            DropColumn("dbo.FileSettings", "FilePath");
            DropColumn("dbo.FileSettings", "SourceID");
            DropColumn("dbo.AddBlogs", "PrivacyID");
        }
    }
}
