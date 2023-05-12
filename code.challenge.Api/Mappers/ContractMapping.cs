using AutoMapper;
using code.challenge.Api.Contracts;
using code.challenge.Api.Contracts.Request;
using code.challenge.Core.Entities;

namespace code.challenge.Api.Mappers
{
    public class ContractMapping : Profile
    {
        public ContractMapping()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<NewCarDto, Car>();            
        }
    }
}
