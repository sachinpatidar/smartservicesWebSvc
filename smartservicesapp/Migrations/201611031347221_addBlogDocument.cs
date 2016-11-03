namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBlogDocument : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogDocuments",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                        FileID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogDocuments");
        }
    }
}
