using Microsoft.AspNetCore.Mvc;
using OnlineGym_Model;
using OnlineGym_Model.Requests;
using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemPreporukeProizvodiController : ControllerBase
    {
        private readonly ISistemPreporukeProizvodi _service;
        public SistemPreporukeProizvodiController(ISistemPreporukeProizvodi service)
        {
            _service = service;
        }

        [HttpGet]
        public List<OnlineGym_Model.Proizvod> Get([FromQuery]Proizvod request)
        {
            return _service.Get(request);
        }
        [HttpGet]
        [Route("GetPreporukaByClan")]
        public List<OnlineGym_Model.Proizvod> GetPreporukaByClan([FromQuery]Clan request)
        {
            return _service.GetPreporukaByClan(request);
        }
    }
}