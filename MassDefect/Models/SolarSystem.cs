﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Models
{
    [Table("SolarSystems")]
    public class SolarSystem
    {
        public SolarSystem()
        {
            this.Stars = new HashSet<Star>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set;}

        public virtual HashSet<Star> Stars { get; set; }
    }
}
