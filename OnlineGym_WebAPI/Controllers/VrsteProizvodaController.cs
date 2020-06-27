using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class VrsteProizvodaController : BaseController<OnlineGym_Model.VrsteProizvoda, object>
    {
        public VrsteProizvodaController(IService<OnlineGym_Model.VrsteProizvoda, object> service) : base(service)
        {
        }
    }
}
