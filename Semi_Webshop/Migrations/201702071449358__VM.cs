namespace Semi_Webshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _VM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Movies", "User_Id");
            AddForeignKey("dbo.Movies", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Movies", new[] { "User_Id" });
            DropColumn("dbo.Movies", "User_Id");
        }
    }
}
