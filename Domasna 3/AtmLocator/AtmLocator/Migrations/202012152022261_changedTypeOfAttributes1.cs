namespace AtmLocator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedTypeOfAttributes1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Atms");
            AlterColumn("dbo.Atms", "ID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Atms", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Atms");
            AlterColumn("dbo.Atms", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Atms", "ID");
        }
    }
}
