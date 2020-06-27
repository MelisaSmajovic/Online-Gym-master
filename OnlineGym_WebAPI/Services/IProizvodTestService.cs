using OnlineGym_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public interface IProizvodTestService
    {
        List<Proizvod> Get();
        Proizvod GetById(int id);
    }
}
