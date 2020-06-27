using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
  public interface IRecenzijeTeretaneService
    {
        List<OnlineGym_Model.RecenzijeTeretane> Get();

        OnlineGym_Model.RecenzijeTeretane GetById(int id);

        OnlineGym_Model.RecenzijeTeretane Insert(RecenzijeTeretaneUpsertRequest request);

        OnlineGym_Model.RecenzijeTeretane Update(int id, RecenzijeTeretaneUpsertRequest request);
    }
}
