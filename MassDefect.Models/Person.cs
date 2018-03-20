using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Models
{
    [Table("Persons")]
    public class Person
    {
        public Person()
        {
            this.Anomalies = new HashSet<Anomaly>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("PlanetId")]
        public int HomePlanet { get; set; }

        public HashSet<Anomaly> Anomalies { get; set; }
    }
}
