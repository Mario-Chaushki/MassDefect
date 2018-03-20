using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models
{
    [Table("Persons")]
    public class Person
    {
        public Person()
        {
            Anomalies = new HashSet<Anomaly>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int HomePlanetId { get; set; }

        //public virtual Star HomePlanet { get; set; }

        public virtual HashSet<Anomaly> Anomalies { get; set; }
    }
}