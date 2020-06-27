using OnlineGym_WebAPI.Services;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class KorisnikUlogeController : BaseCRUDController<OnlineGym_Model.KorisnikUloge, KorisnikUlogaSearchRequest, KorisnikUlogaUpsertRequest, KorisnikUlogaUpsertRequest>
    {
        public KorisnikUlogeController(ICRUDService<OnlineGym_Model.KorisnikUloge, KorisnikUlogaSearchRequest, KorisnikUlogaUpsertRequest, KorisnikUlogaUpsertRequest> service) : base(service)
        {
        }
    }
}
