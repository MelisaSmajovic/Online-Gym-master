using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineGym_Model.Requests;
using OnlineGym_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
        [Authorize]
        [Route("api/[controller]")]
        [ApiController]
        public class IzlazController : ControllerBase
        {
            private readonly IIzlazService _service;
            public IzlazController(IIzlazService service)
            {
                _service = service;
            }
            [HttpGet]
            public List<OnlineGym_Model.Izlazi> Get([FromQuery]IzlazSearchRequest request)
            {
                return _service.Get(request);
            }
            [HttpPost]
            public OnlineGym_Model.Izlazi Insert(IzlazUpsertRequest request)
            {
                return _service.Insert(request);
            }
            [HttpPut("{id}")]
            public OnlineGym_Model.Izlazi Update(IzlazUpsertRequest request)
            {
                return _service.Update(request);
            }
            [HttpGet("{id}")]
            public OnlineGym_Model.Izlazi GetById(int id)
            {
                return _service.GetById(id);
            }
        }
    }

