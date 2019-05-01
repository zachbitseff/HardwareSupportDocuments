namespace HardwareSupportDocuments.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProjectsDB : DbContext
    {
        // Your context has been configured to use a 'ProjectsDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HardwareSupportDocuments.Models.ProjectsDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProjectsDB' 
        // connection string in the application configuration file.
        public ProjectsDB()
            : base("name=ProjectsDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        //public virtual DbSet<Projects> Project { get; set; }

       // public virtual System.Data.Entity.DbSet<HardwareSupportDocs.Models.ErrorCodes> ErrorCodes { get; set; }

        //public virtual System.Data.Entity.DbSet<HardwareSupportDocs.Models.FaultRecoveryLog> FaultRecoveryLogs { get; set; }

        //public virtual System.Data.Entity.DbSet<HardwareSupportDocs.Models.FunctionalTestingLog> FunctionalTestingLogs { get; set; }

        //public virtual System.Data.Entity.DbSet<HardwareSupportDocs.Models.DeficiencyReport> DeficiencyReports { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}