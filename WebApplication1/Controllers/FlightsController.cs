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
    public class FlightsController : ControllerBase
    {
        private readonly IflightService _flightService;
        private readonly IMapper _mapper ;
        public FlightsController(IflightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        // GET: api/<FlightsController>
        [HttpGet]
        public async Task<ActionResult<Flight>> Get()
        {
            var listFlight = await _flightService.GettAllAsync();
            var newListFlight=_mapper.Map<IEnumerable<FlightDto>>(listFlight);
            return Ok(newListFlight);
        }

        // GET api/<FlightsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var flight= await _flightService.GetByIdAsync(id);
            var newFlight= _mapper.Map<FlightDto>(flight);
            return Ok(newFlight);
        }

        // POST api/<FlightsController>
        [HttpPost]
        public async Task Post([FromBody] FlightDto f)
        {
            var filghtToAdd = _mapper.Map<Flight>(f);
            await _flightService.PostNewFlightAsync(filghtToAdd);
        }

        // PUT api/<FlightsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] FlightDto f)
        {
            var filghtToAdd = _mapper.Map<Flight>(f);
            await _flightService.PutFlightAsync(id, filghtToAdd );
        }

        // DELETE api/<FlightsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _flightService.DeleteFlightAsync(id);
        }
    }
}
