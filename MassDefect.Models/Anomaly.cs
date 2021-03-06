﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassDefect.Models;

namespace MassDefect.Models
{
    [Table("Anomalies")]
    public class Anomaly
    {
        public Anomaly()
        {
            this.Victims = new HashSet<Person>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("OriginPlanetId")]
        public int OriginPlanet { get; set; }

        [ForeignKey("TeleportPlanetId")]
        public int TeleportPlanet { get; set; }

        public HashSet<Person> Victims { get; set; }
    }
}
