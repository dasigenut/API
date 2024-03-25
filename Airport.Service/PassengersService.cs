using Aairport.Data.Repositories;
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
    public class PassengersService:IpassengerService
    {
        private readonly IpassengerRepository _passengerRepository;
        private Passenger foundPassenger;

        public int CountPassenger { get; private set; }

        public PassengersService(IpassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<IEnumerable<Passenger>>GettAllAsync()
        {
            return await _passengerRepository.GetListAsync();
        }
        public async Task<Passenger> GetByIdAsync(int id)
        {
            var list = await _passengerRepository.GetListAsync();
            Passenger foundId = list.First(x => x.Id == id);
            if (foundId == null)
            {
                return null;
            }
            return foundId;
        }
        public async Task PostNewPassengerAsync(Passenger p)
        {
            await _passengerRepository.PostPassengerAsync(p);
            CountPassenger++;
        }
        public async Task PutPassengerAsync(int Id, Passenger P)
        {
             await _passengerRepository.UpdatePassengerAsync(Id, P);
        }
        public async Task DeletePassengerAsync(int Id)
        {
            var index = await GetByIdAsync(Id);
            if (index != null)
            {
                await _passengerRepository.RemovePassengerAsync(index);
            }
        }
    }
}

