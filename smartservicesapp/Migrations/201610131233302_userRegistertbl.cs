namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userRegistertbl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserRegister", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRegister", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
