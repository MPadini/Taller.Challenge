using code.challenge.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code.challenge.Core.ServiceInterfaces
{
    public interface IGetCarsService
    {
        Task<IEnumerable<Car>> GetAllAsync();

        Task<Car> GetAsync(int id);
    }
}
