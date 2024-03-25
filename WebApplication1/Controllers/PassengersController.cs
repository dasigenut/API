using Airport.Core.DTOs;
using Airport.Core.Services;
using Airport.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly IpassengerService _passengerService;
        private readonly IMapper _mapper;
        public PassengersController(IpassengerService passengerService,IMapper mapper)
        {
            _passengerService = passengerService;
            _mapper = mapper;
        }
        // GET: api/<PassengersController>
        [HttpGet]
        public async Task<ActionResult<Passenger>> Get()
        {
            var listPassenger= await _passengerService.GettAllAsync();
            var newListPassenger = _mapper.Map<IEnumerable<PassengerDto>>(listPassenger);
            return Ok(newListPassenger);
        }

        // GET api/<PassengersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
           var passenger= await _passengerService.GetByIdAsync(id);
           var newPassenger = _mapper.Map<PassengerDto>(passenger);
            return Ok(newPassenger);
        }

        // POST api/<PassengersController>
        [HttpPost]
        public async Task Post([FromBody] PassengerDto P)
        {
            var passengerToAdd = _mapper.Map<Passenger>(P);
            await _passengerService.PostNewPassengerAsync(passengerToAdd);
        }

        // PUT api/<PassengersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PassengerDto P)
        {
            var passengerToAdd = _mapper.Map<Passenger>(P);
            await _passengerService.PutPassengerAsync(id, passengerToAdd);
        }

        // DELETE api/<PassengersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _passengerService.DeletePassengerAsync(id);
        }
    }
}
