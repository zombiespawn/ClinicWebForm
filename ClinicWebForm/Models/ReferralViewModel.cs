﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWebForm.Models
{
    public class ReferralViewModel
    {
        [Required]
        public virtual CHW CHW { get; set; }

        [Required]
        public virtual Clinic Clinic { get; set; }

        [Required]
        public virtual Ward Ward { get; set; }

        [Required]
        public virtual Referral Referral { get; set; }

        [Required]
        public virtual IndividualMember Member { get; set; }

        [Required]
        public virtual List<Questions> Questions { get; set; }
    }
}