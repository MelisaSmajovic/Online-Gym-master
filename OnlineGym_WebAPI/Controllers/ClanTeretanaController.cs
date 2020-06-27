using OnlineGym_WebAPI.Services;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class ClanTeretanaController : BaseCRUDController<OnlineGym_Model.ClanTeretana, ClanTeretanaSearchRequest, ClanTeretanaUpsertRequest, ClanTeretanaUpsertRequest>
    {
        public ClanTeretanaController(ICRUDService<OnlineGym_Model.ClanTeretana, ClanTeretanaSearchRequest, ClanTeretanaUpsertRequest, ClanTeretanaUpsertRequest> service) : base(service)
        {
        }
    }
}
