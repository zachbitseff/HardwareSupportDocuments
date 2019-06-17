using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HardwareSupportDocuments.Models
{
    public class ErrorCodes
    {

        [Key]
        public int ErrorID { get; set; }

        [Display(Name = "Error Code")]
        public string ErrorCode { get; set; }


        [Display(Name = "Error Code Description")]
        public string ErrorCodeDescription { get; set; }

        public string Subsystem { get; set; }

        public string Component { get; set; }

        [Display(Name = "Failure Mode")]
        public string FailureMode { get; set; }

        // Foreign Key
        [Display(Name = "Fault Log ID")]
        public int FaultLogID { get; set; }
        public virtual FaultRecoveryLog FaultLog { get; set; }

    }
}