using Airport.Core.Repositories;
using Airport.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Airport.Service
{
    public class FlightsService: IflightService
    {
        private readonly IflightRepository _flightRepository;
        private Flight foundFlight;

        public int CountFlight { get; private set; }

        public FlightsService(IflightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<IEnumerable<Flight>> GettAllAsync()
        {
          return await _flightRepository.GetListAsync();
        }
        public async Task<Flight> GetByIdAsync( int id)
        {
            var list = await _flightRepository.GetListAsync();
            Flight foundId = list.First(x => x.Id == id);
            if (foundId == null)
            {
                return  null;
            }
            return foundId;
        }
        public async Task PostNewFlightAsync(Flight f)
        {
            CountFlight++;
            await _flightRepository.PostFlightAsync(f);
        }
        public async Task PutFlightAsync(int Id, Flight f)
        {
             await _flightRepository.UpdateFlightAsync(Id, f);  
        }

        public async Task DeleteFlightAsync(int Id)
        {
            var index =await GetByIdAsync(Id);
            if (index != null)
            {
               await _flightRepository.RemoveFlightAsync(index);
            }
        }
    }
}
