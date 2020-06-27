using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
  public interface IKorisnikUlogeService
    {
        List<OnlineGym_Model.KorisnikUloge> Get();
      
    }
}
