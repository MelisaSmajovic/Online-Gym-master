using OnlineGym_Model.Requests;
using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class ObavijestController : BaseCRUDController<OnlineGym_Model.Obavijest, ObavijestSearchRequest, ObavijestUpsertRequest, ObavijestUpsertRequest>
    {
        public ObavijestController(ICRUDService<OnlineGym_Model.Obavijest, ObavijestSearchRequest, ObavijestUpsertRequest, ObavijestUpsertRequest> service) : base(service)
        {
        }
    }
}
