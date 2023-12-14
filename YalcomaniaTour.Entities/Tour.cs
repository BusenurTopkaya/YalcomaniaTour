using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalcomaniaTour.Entities
{
    [Table("Tours")]
    public  class Tour
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TourId { get; set; }
        public string TourName { get; set; }
        public double FullPrice { get; set; }
        public double HalfPrice { get; set; }
        public double GuestPrice { get; set; }

        public DateTime TourDate { get; set; }

        [DisplayName("Aktif"),]
        public bool IsActive { get; set; }
        public string Tourproperties { get; set; }
        public int VehicleId { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }


    }
}
