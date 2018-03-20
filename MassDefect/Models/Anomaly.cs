using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models
{
    [Table("Anomalies")]
    public class Anomaly
    {
        public Anomaly()
        {
            Victims = new HashSet<Person>();
        }

        [Key]
        public int Id { get; set; }

        
        public int OriginPlanetId { get; set; }

        [InverseProperty("TeleportAnomalies")]
        public virtual Planet OriginPlanet { get; set; }

        public int TeleportPlanetId { get; set; }
        
        [InverseProperty("OriginAnomalies")]
        public virtual Planet TeleportPlanet { get; set; }
        
        public virtual HashSet<Person> Victims { get; set; }
    }
}