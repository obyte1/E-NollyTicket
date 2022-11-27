using Microsoft.EntityFrameworkCore;
using NollyTickets.Ng.Data.Base;
using NollyTickets.Ng.Models;

namespace NollyTickets.Ng.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
      

        public ActorsService(ApplicationDbContext contex): base(contex) { }
       
      
         
    }
}
