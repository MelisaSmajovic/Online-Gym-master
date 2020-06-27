using OnlineGym_Model;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public interface IIzlazService
    {
        List<Izlazi> Get(IzlazSearchRequest request);
        OnlineGym_Model.Izlazi Insert(IzlazUpsertRequest request);
        OnlineGym_Model.Izlazi Update(IzlazUpsertRequest request);
        OnlineGym_Model.Izlazi GetById(int id);
    }
}
