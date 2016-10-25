namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madechangesinuserregistration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegister", "FileName", c => c.String());
            AddColumn("dbo.UserRegister", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRegister", "Discriminator");
            DropColumn("dbo.UserRegister", "FileName");
        }
    }
}
