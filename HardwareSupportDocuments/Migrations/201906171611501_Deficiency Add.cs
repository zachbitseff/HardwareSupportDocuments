namespace HardwareSupportDocuments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeficiencyAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeficiencyReports", "Deficiency", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeficiencyReports", "Deficiency");
        }
    }
}
