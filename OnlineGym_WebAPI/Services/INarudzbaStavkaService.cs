using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public interface INarudzbaStavkaService
    {
        List<OnlineGym_Model.NarudzbeStavke> Get(NarudzbaStavkaSearchRequest request);
        OnlineGym_Model.NarudzbeStavke Insert(NarudzbaStavkaUpsertRequest request);
        bool Delete(int id);
    }
}
