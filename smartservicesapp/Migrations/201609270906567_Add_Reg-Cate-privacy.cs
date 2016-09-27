namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_RegCateprivacy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 150, unicode: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.PrivacyType",
                c => new
                    {
                        PrivacyID = c.Int(nullable: false, identity: true),
                        PrivacyTypeName = c.String(maxLength: 150, unicode: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PrivacyID);
            
            CreateTable(
                "dbo.UserRegister",
                c => new
                    {
                        RegistrationID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 150, unicode: false),
                        LastName = c.String(maxLength: 150, unicode: false),
                        UserName = c.String(maxLength: 150, unicode: false),
                        Email = c.String(maxLength: 150, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        Mobile = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RegistrationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRegister");
            DropTable("dbo.PrivacyType");
            DropTable("dbo.Category");
        }
    }
}
