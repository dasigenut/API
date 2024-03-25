using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Airport.Core.Services
{
    public interface IpassengerService
    {
        public Task<IEnumerable<Passenger>> GettAllAsync();
        public Task<Passenger> GetByIdAsync(int id);
        public Task PostNewPassengerAsync(Passenger p);
        public Task PutPassengerAsync(int Id, Passenger P);
        public Task DeletePassengerAsync(int Id);
    }
}
