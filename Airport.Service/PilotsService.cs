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
    public class PilotsService:IpilotService
    {
        private readonly IpilotRepository _ipilotRepository;
        private object foundPilot;

        public int CountPilot { get; private set; }

        public PilotsService(IpilotRepository ipilotRepository)
        {
            _ipilotRepository = ipilotRepository;
        }

        public List<Pilot> GettAll()
        {
            return _ipilotRepository.GetList();
        }
        public Pilot GetById(int id)
        {
            Pilot foundId = _ipilotRepository.GetList().Find(x => x.Id == id);
            if (foundId == null)
            {
                return null;
            }
            return foundId;
        }
        public void PostNewPilot(Pilot p)
        {
            _ipilotRepository.PostPilotAsync(p);
            CountPilot++;
        }
        public void PutPilot(int Id, Pilot p)
        {
            int index = _ipilotRepository.GetList().FindIndex( x => x.Id == Id);
            if (index != -1)
            {
                _ipilotRepository.UpdatePilotAsync(index, p);                
            }
        }
        public void DeletePilot(int Id)
        {
            int index = _ipilotRepository.GetList().FindIndex( x => x.Id == Id);
            if (index != -1)
            {
                _ipilotRepository.RemovePilotAsync(index);
            }
        }
    }
}
