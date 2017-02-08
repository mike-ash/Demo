namespace Semi_Webshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _UpdatedMovieClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Movies", new[] { "User_Id" });
            AddColumn("dbo.Movies", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Movies", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "Description");
            CreateIndex("dbo.Movies", "User_Id");
            AddForeignKey("dbo.Movies", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
