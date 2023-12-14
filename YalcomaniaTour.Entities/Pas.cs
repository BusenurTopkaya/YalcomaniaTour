using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalcomaniaTour.Entities
{
    [Table("Pas")]
    public class Pas
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PasId { get; set; }
        public string Sirket { get; set; }
        public int TicketId { get; set; }

        public virtual Ticket Tickets { get; set; }
    }
}
