namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_privacyCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "CatOrderBy", c => c.Int(nullable: false));
            AddColumn("dbo.PrivacyType", "PrivacyOrderBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PrivacyType", "PrivacyOrderBy");
            DropColumn("dbo.Category", "CatOrderBy");
        }
    }
}
