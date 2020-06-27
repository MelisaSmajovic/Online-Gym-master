using OnlineGym_WebAPI.Services;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Authorization;

namespace OnlineGym_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NarudzbaController : ControllerBase
    {
        private readonly INarudzbaService _service;
        public NarudzbaController(INarudzbaService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<OnlineGym_Model.Narudzbe> Get([FromQuery]NarudzbaSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet]
        [Route("GetMaxNarudzbaId")]
        public int GetMaxNarudzbaId()
        {
            return _service.GetMaxNarudzbaId();
        }
  
        [HttpPost]
        public OnlineGym_Model.Narudzbe Insert(NarudzbaUpsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public OnlineGym_Model.Narudzbe Update(NarudzbaUpsertRequest request)
        {
            return _service.Update(request);
        }
  

        [HttpGet("{id}")]
        public OnlineGym_Model.Narudzbe GetById(int id)
        {
            return _service.GetById(id);
        }
    }


}
