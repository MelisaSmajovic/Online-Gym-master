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
    public class ClanController : ControllerBase
    {
        private readonly IClanService _service;
        public ClanController(IClanService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<OnlineGym_Model.Clan> Get([FromQuery]ClanSearchRequest request)
        {
            return _service.Get(request);
        }

        [AllowAnonymous]
        [HttpPost]
        public OnlineGym_Model.Clan Insert(ClanUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public OnlineGym_Model.Clan Update(int id, [FromBody]ClanUpsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        public OnlineGym_Model.Clan GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
