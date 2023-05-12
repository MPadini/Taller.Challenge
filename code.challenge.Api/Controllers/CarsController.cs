using AutoMapper;
using code.challenge.Api.Contracts;
using code.challenge.Api.Contracts.Request;
using code.challenge.Core.Entities;
using code.challenge.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace code.challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ILogger<CarsController> _logger;
        private readonly IMapper _mapper;
        private readonly IGetCarsService _getCarsService;
        private readonly IDeleteCarService _deleteCarService;
        private readonly ISaveCarService _saveCarService;
        private IUpdateCarService _updateCarService;

        public CarsController(
            ILogger<CarsController> logger,
            IMapper mapper,
            IGetCarsService getCarsService,
            IDeleteCarService deleteCarService,
            ISaveCarService saveCarService,
            IUpdateCarService updateCarService)
        {
            _logger = logger;
            _mapper = mapper;
            _getCarsService = getCarsService;
            _deleteCarService = deleteCarService;
            _saveCarService = saveCarService;
            _updateCarService = updateCarService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetAllAsync()
        {
            var results = await _getCarsService.GetAllAsync();
            if (results == null || !results.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<CarDto>>(results));
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetAsync([FromRoute]int id)
        {
            var results = await _getCarsService.GetAsync(id);
            if (results == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CarDto>(results));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _deleteCarService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdateAsync([FromBody] CarDto car)
        {
            if (car == null)
            {
                return BadRequest("Car can not be null");
            }

            await _updateCarService.UpdateAsync(_mapper.Map<Car>(car));

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> AddAsync([FromBody] NewCarDto car)
        {
            if (car == null)
            {
                return BadRequest("Car can not be null");
            }

            var newCar = await _saveCarService.SaveAsync(_mapper.Map<Car>(car));

            return Ok(_mapper.Map<CarDto>(newCar));
        }
    }
}
