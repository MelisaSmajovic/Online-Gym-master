using OnlineGym_Model.Requests;
using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class RecenzijeProizvodaController : BaseCRUDController<OnlineGym_Model.RecenzijeProizvoda, RecenzijeProizvodaSearchRequest, RecenzijeProizvodaUpsertRequest, RecenzijeProizvodaUpsertRequest>
    {
        public RecenzijeProizvodaController(ICRUDService<OnlineGym_Model.RecenzijeProizvoda, RecenzijeProizvodaSearchRequest, RecenzijeProizvodaUpsertRequest, RecenzijeProizvodaUpsertRequest> service) : base(service)
        {
        }
    }
}
