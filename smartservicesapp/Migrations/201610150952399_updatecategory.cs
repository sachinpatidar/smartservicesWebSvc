namespace smartservicesapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "CatClassName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "CatClassName");
        }
    }
}
