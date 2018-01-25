namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attbiuteAnnotationChangedBookClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false));
        }
    }
}
