using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalcomaniaTour.Entities
{
    [Table("Regions")]
    public  class Region
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegionId { get; set; }
        [StringLength(25)]
        public string RegionName { get; set; }

        public int HotelId { get; set; }

        public DateTime ServiceHour { get; set; }

        public virtual Hotel Hotels { get; set; }
    }
}
