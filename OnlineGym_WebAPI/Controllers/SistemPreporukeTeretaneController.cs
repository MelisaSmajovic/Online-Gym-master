using Microsoft.AspNetCore.Mvc;
using OnlineGym_Model;
using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SistemPreporukeTeretaneController : ControllerBase
    {
        private readonly ISistemPreporukeTeretane _service;
        public SistemPreporukeTeretaneController(ISistemPreporukeTeretane service)
        {
            _service = service;
        }

        [HttpGet]
        public List<OnlineGym_Model.Teretana> Get([FromQuery]int id)
        {
            return _service.Get(id);
        }
        [HttpGet]
        [Route("GetPreporukaByTeretana")]
        public List<OnlineGym_Model.Teretana> GetPreporukaByTeretana([FromQuery]Teretana request)
        {
            return _service.GetPreporukaByTeretana(request);
        }
    }
}
