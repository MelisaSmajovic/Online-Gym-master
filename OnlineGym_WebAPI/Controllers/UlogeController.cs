using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class UlogeController : BaseController<OnlineGym_Model.Uloga, object>
    {
        public UlogeController(IService<OnlineGym_Model.Uloga, object> service) : base(service)
        {
        }
    }
}
