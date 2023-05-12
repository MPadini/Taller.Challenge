using code.challenge.Core.Entities;
using code.challenge.Core.RepositoryInterfaces;
using code.challenge.Core.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace code.challenge.Service.Services
{
    public class DeleteCarService : IDeleteCarService
    {
        private readonly IRepository<Car> _repository;

        public DeleteCarService(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
            var car = await _repository.GetByIdAsync(id);
            if (car == null)
            {
                throw new ArgumentException(nameof(car));
            }

            await _repository.DeleteAsync(car);
        }
    }
}
