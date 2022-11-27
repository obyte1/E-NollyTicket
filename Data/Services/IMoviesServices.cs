using NollyTickets.Ng.Data.Base;
using NollyTickets.Ng.Data.ViewModels;
using NollyTickets.Ng.Models;

namespace NollyTickets.Ng.Data.Services
{
    public interface IMoviesServices : IEntityBaseRepository<Movie>
    {
       Task<Movie> GetMovieByIdAsync(int id);
       Task<NewMovieDropDownVM> GetNewMovieDropDownValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
