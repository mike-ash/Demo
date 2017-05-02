using Semi_Webshop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Semi_Webshop.services
{
    public interface IMovieService
    {
        Task<Serie> FindAsync(string id);
        Task<IQueryable<Serie>> GetSeriesAsync();
        Task<IQueryable<Serie>> GetDealsAsync();
    }
}
