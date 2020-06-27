using OnlineGym_Model.Requests;
using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class RecenzijeTeretaneController : BaseCRUDController<OnlineGym_Model.RecenzijeTeretane, RecenzijeTeretaneSearchRequest, RecenzijeTeretaneUpsertRequest, RecenzijeTeretaneUpsertRequest>
    {
        public RecenzijeTeretaneController(ICRUDService<OnlineGym_Model.RecenzijeTeretane, RecenzijeTeretaneSearchRequest, RecenzijeTeretaneUpsertRequest, RecenzijeTeretaneUpsertRequest> service) : base(service)
        {
        }
    }
}
