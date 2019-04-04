namespace PastaHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewDatasets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        HomeNumber = c.String(),
                        LocalNumber = c.Int(nullable: false),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        DishId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Subcategory = c.String(),
                        Ingredients = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DishId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Client_ClientId = c.Int(),
                        Dish_DishId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId)
                .ForeignKey("dbo.Dishes", t => t.Dish_DishId)
                .Index(t => t.Client_ClientId)
                .Index(t => t.Dish_DishId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Dish_DishId", "dbo.Dishes");
            DropForeignKey("dbo.Orders", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "Dish_DishId" });
            DropIndex("dbo.Orders", new[] { "Client_ClientId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Dishes");
            DropTable("dbo.Clients");
        }
    }
}
