﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWebForm.Models
{
    public class HouseholdRegistrationViewModel
    {
        [Required]
        public virtual CHW CHW { get; set; }

        [Required]
        public virtual Clinic Clinic { get; set; }

        [Required]
        public virtual Ward Ward { get; set; }

        [Required]
        public virtual House House { get; set; }

        [Required]
        public virtual List<IndividualMember> Members { get; set; }

        [Required]
        public virtual List<Questions> Questions { get; set; }
    }
}