using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalcomaniaTour.Entities
{
    [Table("Revenues")]
    public class Revenue
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RevenueId { get; set; }
        [StringLength(250), Required]
        public string Explanation { get; set; }
        public double Gain { get; set; }

        public DateTime RevenueDate { get; set; }
    }
}
