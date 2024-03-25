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
   
    public class PassengerRepository:IpassengerRepository
    {
        private readonly DataContext _context;
        public PassengerRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Passenger>> GetListAsync()
        {
            return await _context.Passengers.Include(p => p.Flight).ToListAsync();
        }
        public async Task PostPassengerAsync(Passenger p)
        {
            _context.Passengers.Add(p);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePassengerAsync(int index, Passenger p)
        {
            var list = await _context.Passengers.ToListAsync();
            Passenger foundPassenger = list.Find(p => p.Id == index);
            if (foundPassenger != null)
            {
                foundPassenger.Name = p.Name;
                foundPassenger.CountryOrigion = p.CountryOrigion;
                foundPassenger.distnationCountry = p.distnationCountry;
                foundPassenger.NumBags = p.NumBags;
                await _context.SaveChangesAsync();
            }
        }
        public async Task RemovePassengerAsync(Passenger index)
        {
            _context.Passengers.Remove(index);
            await _context.SaveChangesAsync();
        }
    }
}
