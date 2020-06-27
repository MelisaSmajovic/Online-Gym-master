using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineGym_WebAPI.Services;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<OnlineGym_Model.Korisnik> Get([FromQuery]KorisniciSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public OnlineGym_Model.Korisnik Insert(KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public OnlineGym_Model.Korisnik Update(int id, [FromBody]KorisniciInsertRequest request)
        {
            return _service.Update(id, request); 
        }

        [HttpGet("{id}")]
        public OnlineGym_Model.Korisnik GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
