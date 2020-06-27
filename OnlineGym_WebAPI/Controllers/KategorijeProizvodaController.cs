using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class KategorijeProizvodaController : BaseController<OnlineGym_Model.KategorijeProizvoda, object>
    {
        public KategorijeProizvodaController(IService<OnlineGym_Model.KategorijeProizvoda, object> service) : base(service)
        {
        }
    }
}
