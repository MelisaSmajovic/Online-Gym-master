using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
   public interface IObavijestService
    {
        List<OnlineGym_Model.Obavijest> Get();
        OnlineGym_Model.Obavijest GetById(int id);

        OnlineGym_Model.Obavijest Insert(ObavijestUpsertRequest request);

        OnlineGym_Model.Obavijest Update(int id, ObavijestUpsertRequest request);
    }
}
