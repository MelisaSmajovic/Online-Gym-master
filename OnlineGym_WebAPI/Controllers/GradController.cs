using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
  
    public class GradController : BaseController<OnlineGym_Model.Gradovi, object>
    {  
        public GradController(IService<OnlineGym_Model.Gradovi, object> service) : base(service)
        {
        }
    }
}
