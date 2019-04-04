namespace PastaHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "HomeNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Telephone", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Reservations", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Clients", "Telephone", c => c.String());
            AlterColumn("dbo.Clients", "HomeNumber", c => c.String());
            AlterColumn("dbo.Clients", "Street", c => c.String());
            AlterColumn("dbo.Clients", "City", c => c.String());
            AlterColumn("dbo.Clients", "Surname", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String());
        }
    }
}
