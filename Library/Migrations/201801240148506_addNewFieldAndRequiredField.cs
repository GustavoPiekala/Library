namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewFieldAndRequiredField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ImgPath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ImgPath");
        }
    }
}
