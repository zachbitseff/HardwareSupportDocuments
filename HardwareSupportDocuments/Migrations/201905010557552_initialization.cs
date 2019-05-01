namespace HardwareSupportDocuments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeficiencyReports",
                c => new
                    {
                        DeficiencyID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        TestConditionsAndResults = c.String(),
                        MissionImpact = c.String(),
                        CauseAnalysis = c.String(),
                        RemedialAction = c.String(),
                    })
                .PrimaryKey(t => t.DeficiencyID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Team = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.FaultRecoveryLogs",
                c => new
                    {
                        FaultLogID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Login = c.String(),
                        ErrorID = c.Int(nullable: false),
                        EventDescription = c.String(),
                        PartsReplaced = c.Boolean(nullable: false),
                        PartNumber = c.String(),
                        RecoverySteps = c.String(),
                        Hyperlinks = c.String(),
                        Results = c.String(),
                        Error_ErrorID = c.Int(),
                    })
                .PrimaryKey(t => t.FaultLogID)
                .ForeignKey("dbo.ErrorCodes", t => t.Error_ErrorID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.Error_ErrorID);
            
            CreateTable(
                "dbo.ErrorCodes",
                c => new
                    {
                        ErrorID = c.Int(nullable: false, identity: true),
                        ErrorCode = c.String(),
                        ErrorCodeDescription = c.String(),
                        Subsystem = c.String(),
                        Component = c.String(),
                        FailureMode = c.String(),
                        FaultLogID = c.Int(nullable: false),
                        FaultLog_FaultLogID = c.Int(),
                        FaultRecoveryLog_FaultLogID = c.Int(),
                    })
                .PrimaryKey(t => t.ErrorID)
                .ForeignKey("dbo.FaultRecoveryLogs", t => t.FaultLog_FaultLogID)
                .ForeignKey("dbo.FaultRecoveryLogs", t => t.FaultRecoveryLog_FaultLogID)
                .Index(t => t.FaultLog_FaultLogID)
                .Index(t => t.FaultRecoveryLog_FaultLogID);
            
            CreateTable(
                "dbo.FunctionalTestingLogs",
                c => new
                    {
                        FunctionalTestingLogID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        Login = c.String(),
                        Date = c.DateTime(nullable: false),
                        TestName = c.String(),
                        CurrentStateProblemDescription = c.String(),
                        ProposedSolution = c.String(),
                        ChangesMadeDuringTest = c.String(),
                        Observations = c.String(),
                        RecommendedChanges = c.String(),
                        ChangeApproved = c.Boolean(nullable: false),
                        Hyperlinks = c.String(),
                        Results = c.String(),
                    })
                .PrimaryKey(t => t.FunctionalTestingLogID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeficiencyReports", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.FunctionalTestingLogs", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.FaultRecoveryLogs", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ErrorCodes", "FaultRecoveryLog_FaultLogID", "dbo.FaultRecoveryLogs");
            DropForeignKey("dbo.FaultRecoveryLogs", "Error_ErrorID", "dbo.ErrorCodes");
            DropForeignKey("dbo.ErrorCodes", "FaultLog_FaultLogID", "dbo.FaultRecoveryLogs");
            DropIndex("dbo.FunctionalTestingLogs", new[] { "ProjectID" });
            DropIndex("dbo.ErrorCodes", new[] { "FaultRecoveryLog_FaultLogID" });
            DropIndex("dbo.ErrorCodes", new[] { "FaultLog_FaultLogID" });
            DropIndex("dbo.FaultRecoveryLogs", new[] { "Error_ErrorID" });
            DropIndex("dbo.FaultRecoveryLogs", new[] { "ProjectID" });
            DropIndex("dbo.DeficiencyReports", new[] { "ProjectID" });
            DropTable("dbo.FunctionalTestingLogs");
            DropTable("dbo.ErrorCodes");
            DropTable("dbo.FaultRecoveryLogs");
            DropTable("dbo.Projects");
            DropTable("dbo.DeficiencyReports");
        }
    }
}
