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

        [Display(Name = "Test Name")]
        public string TestName { get; set; }

        [Display(Name = "Current State Problem Description")]
        public string CurrentStateProblemDescription { get; set; }

        [Display(Name = "Proposed Solution")]
        public string ProposedSolution { get; set; }

        [Display(Name = "Changes Made During Test")]
        public string ChangesMadeDuringTest { get; set; }

        public string Observations { get; set; }

        [Display(Name = "Recommended Changes")]
        public string RecommendedChanges { get; set; }

        [Display(Name = "Change Approved?")]
        public Boolean ChangeApproved { get; set; }

        public string Hyperlinks { get; set; }

        public string Results { get; set; }
    }
}