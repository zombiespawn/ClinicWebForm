﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWebForm.Models
{
    public class IndividualMember
    {
        [Key]
        public int Id { get; set; }
        public virtual Household Household { get; set; }
        public virtual Visit Visit { get; set; }
        public virtual NextOfKin NextOfKin { get; set; }
        public virtual RelationshipStatus RelationshipStatus { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Tel { get; set; }
        public int BirthWeight { get; set; }
        public bool ReceivingGrant { get; set; }
        public bool Head { get; set; }
    }
}