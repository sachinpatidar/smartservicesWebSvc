namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addupdateblogComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                        Comment = c.String(unicode: false, storeType: "text"),
                        UserID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            AddColumn("dbo.AddBlogs", "UserLikes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AddBlogs", "UserLikes");
            DropTable("dbo.BlogComments");
        }
    }
}
