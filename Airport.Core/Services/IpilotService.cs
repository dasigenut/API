using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Airport.Core.Services
{
    public interface IpilotService
    {
        public List<Pilot> GettAll();
        Pilot GetById(int id);
        public void PostNewPilot(Pilot p);
        public void PutPilot(int Id, Pilot p);
        public void DeletePilot(int Id);
    }
}
