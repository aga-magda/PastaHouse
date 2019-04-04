namespace PastaHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrderModelAndAddCartModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Dish_DishId", "dbo.Dishes");
            DropIndex("dbo.Orders", new[] { "Dish_DishId" });
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CartId);
            
            AddColumn("dbo.Dishes", "Cart_CartId", c => c.Int());
            AddColumn("dbo.Orders", "Cart_CartId", c => c.Int());
            CreateIndex("dbo.Dishes", "Cart_CartId");
            CreateIndex("dbo.Orders", "Cart_CartId");
            AddForeignKey("dbo.Dishes", "Cart_CartId", "dbo.Carts", "CartId");
            AddForeignKey("dbo.Orders", "Cart_CartId", "dbo.Carts", "CartId");
            DropColumn("dbo.Orders", "Count");
            DropColumn("dbo.Orders", "Value");
            DropColumn("dbo.Orders", "Dish_DishId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Dish_DishId", c => c.Int());
            AddColumn("dbo.Orders", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Count", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "Cart_CartId", "dbo.Carts");
            DropForeignKey("dbo.Dishes", "Cart_CartId", "dbo.Carts");
            DropIndex("dbo.Orders", new[] { "Cart_CartId" });
            DropIndex("dbo.Dishes", new[] { "Cart_CartId" });
            DropColumn("dbo.Orders", "Cart_CartId");
            DropColumn("dbo.Dishes", "Cart_CartId");
            DropTable("dbo.Carts");
            CreateIndex("dbo.Orders", "Dish_DishId");
            AddForeignKey("dbo.Orders", "Dish_DishId", "dbo.Dishes", "DishId");
        }
    }
}
