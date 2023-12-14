using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalcomaniaTour.Entities
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        public int TourId { get; set; }
        [StringLength(25)]
        public string CustomerName { get; set; }
        public int RegionId { get; set; }
        public string BranchOffice { get; set; }

        public int UserId { get; set; }
        public double TotalSum { get; set; }
        public double Paid { get; set; }
        public double Rest { get; set; }

        public DateTime TicketDate { get; set; }

        public virtual Tour Tours { get; set; }
        public virtual Region Regions { get; set; }
        public virtual TourUser User { get; set; }
        public virtual ICollection<Pas> Pas { get; set; }
    }
}
