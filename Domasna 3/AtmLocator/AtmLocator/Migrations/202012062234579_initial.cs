namespace AtmLocator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Name = c.String(),
                        Street = c.String(),
                        OpenHours = c.String(),
                        Wheelchair = c.Boolean(nullable: false),
                        Drive_Through = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Atms");
        }
    }
}
