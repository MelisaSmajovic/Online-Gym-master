using OnlineGym_Model;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public interface INarudzbaService
    {
        List<Narudzbe> Get(NarudzbaSearchRequest request);
        OnlineGym_Model.Narudzbe Insert(NarudzbaUpsertRequest request);
        OnlineGym_Model.Narudzbe Update(NarudzbaUpsertRequest request);
        OnlineGym_Model.Narudzbe GetById(int id);
        int GetMaxNarudzbaId();
    }
}
