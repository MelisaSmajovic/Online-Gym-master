using OnlineGym_WebAPI.Services;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class TeretanaController : BaseCRUDController<OnlineGym_Model.Teretana, TeretanaSearchRequest, TeretanaUpsertRequest, TeretanaUpsertRequest>
    {
        public TeretanaController(ICRUDService<OnlineGym_Model.Teretana, TeretanaSearchRequest, TeretanaUpsertRequest, TeretanaUpsertRequest> service) : base(service)
        {
        }
    }
}
