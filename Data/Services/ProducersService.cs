using NollyTickets.Ng.Data.Base;
using NollyTickets.Ng.Models;

namespace NollyTickets.Ng.Data.Services
{
    public class ProducersService :EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(ApplicationDbContext context): base(context)
        {

        }
    }
}
