using NollyTickets.Ng.Data.Base;
using NollyTickets.Ng.Models;

namespace NollyTickets.Ng.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
