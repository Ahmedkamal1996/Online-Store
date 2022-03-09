namespace OnlineStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeCategoryNameAndProductNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Name", c => c.String());
            AlterColumn("dbo.Category", "Name", c => c.String());
        }
    }
}
