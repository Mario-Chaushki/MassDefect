using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models
{
    [Table("Planets")]
    public class Planet
    {
        public Planet()
        {
            this.Anomalies = new HashSet<Anomaly>();
            this.OriginAnomalies = new HashSet<Anomaly>();
            this.TeleportAnomalies = new HashSet<Anomaly>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int SunId { get; set; }

        public virtual Star Sun { get; set; }

        public int SolarSystemId { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }

        public virtual HashSet<Anomaly> Anomalies { get; set; }
        
        public virtual HashSet<Anomaly> OriginAnomalies { get; set; }

        public virtual HashSet<Anomaly> TeleportAnomalies { get; set; }
    }
}