using OnlineGym_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public interface IProizvodService
    {
        List<Proizvod> Get();
    }
}
