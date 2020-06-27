using OnlineGym_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public interface ISistemPreporukeTeretane
    {
        List<OnlineGym_Model.Teretana> Get(int request);
        List<OnlineGym_Model.Teretana> GetPreporukaByTeretana(Teretana request);
    }
}
