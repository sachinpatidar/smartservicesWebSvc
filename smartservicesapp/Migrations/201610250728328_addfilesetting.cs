namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfilesetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileType = c.String(),
                        File = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileSettings");
        }
    }
}
