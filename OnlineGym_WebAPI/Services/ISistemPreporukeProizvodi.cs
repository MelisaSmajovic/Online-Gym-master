using OnlineGym_Model;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{

    public interface ISistemPreporukeProizvodi
    {
        List<OnlineGym_Model.Proizvod> Get(Proizvod request);
        List<OnlineGym_Model.Proizvod> GetPreporukaByClan(Clan request);

    }
}
