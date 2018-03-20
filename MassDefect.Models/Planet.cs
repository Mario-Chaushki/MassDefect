using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Models
{
    [Table("Planets")]
    public class Planet
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [ForeignKey("Star")]
        public int SunId { get; set; }
        
        [ForeignKey("SolarSystemId")]
        public int SolarSystem { get; set; }
    }
}
