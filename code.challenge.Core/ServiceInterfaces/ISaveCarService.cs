using code.challenge.Core.Entities;
using System.Threading.Tasks;

namespace code.challenge.Core.ServiceInterfaces
{
    public interface ISaveCarService
    {
        Task<Car> SaveAsync(Car car);
    }
}
