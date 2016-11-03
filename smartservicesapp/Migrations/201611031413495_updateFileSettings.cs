namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFileSettings : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FileSettings", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileSettings", "File", c => c.Binary(storeType: "image"));
        }
    }
}
