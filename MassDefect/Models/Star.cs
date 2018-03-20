using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models
{
    [Table("Stars")]
    public class Star
    {
        public Star()
        {
            this.Planets = new HashSet<Planet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int? SolarSystemId { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }

        public virtual HashSet<Planet> Planets { get; set; }
    }
}