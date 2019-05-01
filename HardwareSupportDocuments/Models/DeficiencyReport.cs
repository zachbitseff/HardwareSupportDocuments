using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HardwareSupportDocuments.Models
{
    public class DeficiencyReport
    {

        // Foreign Key
        public int ProjectID { get; set; }
        public virtual Projects Project { get; set; }

        [Key]
        public int DeficiencyID { get; set; }

        [Display(Name = "Test Conditions And Results")]
        public string TestConditionsAndResults { get; set; }

        [Display(Name = "Mission Impact")]
        public string MissionImpact { get; set; }

        [Display(Name = "Cause Analysis")]
        public string CauseAnalysis { get; set; }

        [Display(Name = "Remedial Action")]
        public string RemedialAction { get; set; }

        [EnumDataType(typeof(Teams))]
        public string Team { get; set; }

        public enum Teams
        {
            PK, // Pack
            S, // Sortation
            IIRA // Integrated Industrial Robotic Arms
        }

    }
}