using code.challenge.Core.Entities;
using System.Threading.Tasks;

namespace code.challenge.Core.ServiceInterfaces
{
    public interface IUpdateCarService
    {
        Task UpdateAsync(Car car);
    }
}
