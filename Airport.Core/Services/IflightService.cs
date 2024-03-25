using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Airport.Core.Services
{
    public interface IflightService
    {
        public Task<IEnumerable<Flight>> GettAllAsync();
        public Task<Flight> GetByIdAsync(int id);
        // Flight GetFlightById(int id);
        public Task PostNewFlightAsync(Flight f);
        public Task PutFlightAsync(int Id, Flight f);
        public Task DeleteFlightAsync(int Id);
    }
}
