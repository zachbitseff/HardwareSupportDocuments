using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HardwareSupportDocuments.Models
{
    public class FaultRecoveryLogs
    {

        // Foreign Key
        public int ProjectID { get; set; }
        public virtual Projects Project { get; set; }

        [Key]
        public int FaultLogID { get; set; }

        public DateTime Date { get; set; }


        public string Login { get; set; }

        public int ErrorID { get; set; }
        //public virtual ErrorCodes Error { get; set; }

        public string EventDescription { get; set; }

        public Boolean PartsReplaced { get; set; }

        public string PartNumber { get; set; }

        public string RecoverySteps { get; set; }

        public string Hyperlinks { get; set; }

        public string Results { get; set; }

        // Navigation property
        //public virtual ICollection<ErrorCodes> ErrorCode { get; set; }

    }
}