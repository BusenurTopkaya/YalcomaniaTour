using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalcomaniaTour.Entities
{
    [Table("Hotels")]
    public class Hotel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string RoomNumber { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
