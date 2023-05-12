using System.Threading.Tasks;

namespace code.challenge.Core.ServiceInterfaces
{
    public interface IDeleteCarService
    {
        Task DeleteAsync(int id);
    }
}
