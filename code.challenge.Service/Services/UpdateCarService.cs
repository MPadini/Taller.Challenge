using code.challenge.Core.Entities;
using code.challenge.Core.RepositoryInterfaces;
using code.challenge.Core.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace code.challenge.Service.Services
{
    public class UpdateCarService : IUpdateCarService
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarService(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task UpdateAsync(Car car)
        {
            var carDb = await _repository.GetByIdAsync(car.Id);
            if (carDb == null)
            {
                throw new ArgumentException(nameof(car));
            }

            await _repository.UpdateAsync(car);
        }
    }
}
