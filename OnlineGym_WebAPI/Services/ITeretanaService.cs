using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public interface ITeretanaService
    {
        List<OnlineGym_Model.Teretana> Get();
    }
}
