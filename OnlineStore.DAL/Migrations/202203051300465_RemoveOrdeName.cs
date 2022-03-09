namespace OnlineStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOrdeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Order", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Order", "Name");
            DropColumn("dbo.Order", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "Name", c => c.String());
            AlterColumn("dbo.Order", "TotalPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "Price", c => c.Double(nullable: false));
        }
    }
}
