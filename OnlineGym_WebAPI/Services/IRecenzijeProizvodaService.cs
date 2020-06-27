using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
   public interface IRecenzijeProizvodaService
    {
        List<OnlineGym_Model.RecenzijeProizvoda> Get();

        OnlineGym_Model.RecenzijeProizvoda GetById(int id);

        OnlineGym_Model.RecenzijeProizvoda Insert(RecenzijeProizvodaUpsertRequest request);

        OnlineGym_Model.RecenzijeProizvoda Update(int id, RecenzijeProizvodaUpsertRequest request);
    }
}
