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
    public class PilotsController : ControllerBase
    {
        private readonly IpilotService _pilotService;
        private readonly IMapper _mapper;
        public PilotsController(IpilotService pilotsService,IMapper mapper)
        {
            _pilotService = pilotsService;
            _mapper = mapper;
        }
        // GET: api/<PilotController>
        [HttpGet]
        public ActionResult<Pilot> Get()
        {
            var listPilot= _pilotService.GettAll();
            var newListPilot=_mapper.Map<IEnumerable<PilotDto>>(listPilot);
            return Ok(newListPilot);
        }

        // GET api/<PilotController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var pilot = _pilotService.GetById(id);
            var newPilot=_mapper.Map<PilotDto>(pilot);
            return Ok(newPilot);
        }

        // POST api/<PilotController>
        [HttpPost]
        public void Post([FromBody] PilotDto p)
        {
            var PilotToAdd=_mapper.Map<Pilot>(p);
            _pilotService.PostNewPilot(PilotToAdd);
        }

        // PUT api/<PilotController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PilotDto p)
        {
            var PilotToAdd =_mapper.Map<Pilot>(p);
            _pilotService.PutPilot(id, PilotToAdd);
        }

        // DELETE api/<PilotController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _pilotService.DeletePilot(id);
        }
    }
}
