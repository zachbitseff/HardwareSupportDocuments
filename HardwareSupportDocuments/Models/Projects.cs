﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HardwareSupportDocuments.Models
{
    public class Projects
    {

        [Key]
        public int ProjectID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        [EnumDataType(typeof(Teams))]
        public string Team { get; set; }

        public enum Teams
        {
            PK, // Pack
            S, // Sortation
            IIRA // Integrated Industrial Robotic Arms
        }


        // Navigation properties
        public virtual ICollection<FaultRecoveryLog> FaultLog { get; set; }

        public virtual ICollection<FunctionalTestingLog> FunctionalTestLog { get; set; }

    }
}