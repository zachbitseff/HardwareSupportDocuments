using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HardwareSupportDocuments.Models
{
    public class FaultRecoveryLog
    {

        // Foreign Key
        public int ProjectID { get; set; }
        public virtual Projects Project { get; set; }


        [Key]
        public int FaultLogID { get; set; }


        public DateTime Date { get; set; }


        public string Login { get; set; }

        [Display(Name = "Error ID")]
        public int ErrorID { get; set; }
        public virtual ErrorCodes Error { get; set; }


        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }

        [Display(Name = "Parts Replaced?")]
        public Boolean PartsReplaced { get; set; }

        [Display(Name = "Part Number")]
        public string PartNumber { get; set; }

        [Display(Name = "Recovery Steps")]
        public string RecoverySteps { get; set; }

        public string Hyperlinks { get; set; }

        public string Results { get; set; }

        // Navigation property
        public virtual ICollection<ErrorCodes> ErrorCode { get; set; }

    }
}