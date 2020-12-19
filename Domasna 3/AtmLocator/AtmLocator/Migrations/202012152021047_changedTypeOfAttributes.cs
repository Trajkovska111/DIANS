namespace AtmLocator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedTypeOfAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Atms", "Wheelchair", c => c.String());
            AlterColumn("dbo.Atms", "Drive_Through", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Atms", "Drive_Through", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Atms", "Wheelchair", c => c.Boolean(nullable: false));
        }
    }
}
