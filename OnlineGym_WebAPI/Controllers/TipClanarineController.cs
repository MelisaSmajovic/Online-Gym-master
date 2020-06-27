using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class TipClanarineController : BaseController<OnlineGym_Model.TipClanarine, object>
    {
        public TipClanarineController(IService<OnlineGym_Model.TipClanarine, object> service) : base(service)
        {
        }
    }
}
