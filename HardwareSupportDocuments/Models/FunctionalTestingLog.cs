using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HardwareSupportDocuments.Models
{
    public class FunctionalTestingLog
    {
        // Foreign Key
        public int ProjectID { get; set; }
        public virtual Projects Project { get; set; }

        [Key]
        public int FunctionalTestingLogID { get; set; }

        public string Login { get; set; }

        public DateTime Date { get; set; }
        public string TestName { get; set; }

        public string CurrentStateProblemDescription { get; set; }

        public string ProposedSolution { get; set; }

        public string ChangesMadeDuringTest { get; set; }

        public string Observations { get; set; }

        public string RecommendedChanges { get; set; }

        public Boolean ChangeApproved { get; set; }

        public string Hyperlinks { get; set; }

        public string Results { get; set; }
    }
}