using code.challenge.Core.Entities;
using code.challenge.Core.RepositoryInterfaces;
using code.challenge.Core.ServiceInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace code.challenge.Service.Services
{
    public class GetCarsService : IGetCarsService
    {
        private readonly IRepository<Car> _repository;

        public GetCarsService(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<Car> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
