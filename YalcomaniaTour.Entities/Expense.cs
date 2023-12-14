using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalcomaniaTour.Entities
{
    [Table("Expenses")]
    public class Expense
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpenseId { get; set; }
        [StringLength(250), Required]
        public string Explanation { get; set; }
        public double Dept { get; set; }

        public DateTime ExpenseDate { get; set; }
    }
}
