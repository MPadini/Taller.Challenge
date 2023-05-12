using code.challenge.Core.Entities;
using code.challenge.Core.RepositoryInterfaces;
using code.challenge.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.challenge.Service.Services
{
    public class SaveCarService : ISaveCarService
    {
        private readonly IRepository<Car> _repository;

        public SaveCarService(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<Car> SaveAsync(Car car)
        {
            return await _repository.AddAsync(car);
        }
    }
}
