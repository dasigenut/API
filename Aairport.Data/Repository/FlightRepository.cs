using Airport.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Aairport.Data.Repositories
{
    public class FlightRepository : IflightRepository
    {
        private readonly DataContext _context;
        public FlightRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Flight>> GetListAsync()
        {
            return await _context.Flights.Include(f => f.Passengers).ToListAsync();

        }
        public async Task PostFlightAsync(Flight f)
        {
            _context.Flights.Add(f);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateFlightAsync(int index, Flight f)
        {
            var list = await _context.Flights.ToListAsync();
            Flight foundFlight=list.Find(f => f.Id == index);
            if (foundFlight != null)
            {
                foundFlight.Date=f.Date;
                foundFlight.LeavingTime=f.LeavingTime;
                foundFlight.ArrivalTime=f.ArrivalTime;
                foundFlight.TerminalNum=f.TerminalNum;
                await _context.SaveChangesAsync();
            }

        }
        public async Task RemoveFlightAsync(Flight index)
        {
            _context.Flights.Remove(index);
            await _context.SaveChangesAsync();
        }
    }
}

