using OnlineGym_WebAPI.Services;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineGym_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NarudzbaStavkaController : ControllerBase
    {
        private readonly INarudzbaStavkaService _service;
        public NarudzbaStavkaController(INarudzbaStavkaService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<OnlineGym_Model.NarudzbeStavke> Get([FromQuery]NarudzbaStavkaSearchRequest request)
        {
            return _service.Get(request);
        }

    
        [HttpPost]
        public OnlineGym_Model.NarudzbeStavke Insert(NarudzbaStavkaUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }
    }

}
