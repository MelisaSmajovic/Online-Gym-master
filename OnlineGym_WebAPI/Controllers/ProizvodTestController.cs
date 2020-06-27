using Microsoft.AspNetCore.Mvc;
using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodTestController : ControllerBase
    {

        private readonly IProizvodTestService _service;
        public ProizvodTestController(IProizvodTestService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public OnlineGym_Model.Proizvod GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<OnlineGym_Model.Proizvod>> Get()
        {
            return _service.Get();
        } 
    }
}
