using eTicket.Data.Base;
using eTicket.Data.ViewModels;
using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public interface IMovieService: IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValue();
        Task AddNewMovieAsync(MovieViewModel data);
        Task UpdateMovieAsync(MovieViewModel data);

    }
}
