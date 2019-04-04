namespace PastaHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAndOrderStatusToOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsActive");
            DropColumn("dbo.Orders", "OrderDateTime");
        }
    }
}
