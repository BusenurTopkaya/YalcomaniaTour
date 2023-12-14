using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalcomaniaTour.BusinessLayer.Abstract;
using YalcomaniaTour.DAL.EntityFramework;
using YalcomaniaTour.Entities;

namespace YalcomaniaTour.BusinessLayer
{
    public class TicketManager:ManagerBase<Ticket>
    {
        DatabaseContext databaseContext = new DatabaseContext();

        public List<Ticket> GetTicketList()
        {
            List<Ticket> tl = databaseContext.Tickets.ToList();
            return tl;
        }
        
    }
}
