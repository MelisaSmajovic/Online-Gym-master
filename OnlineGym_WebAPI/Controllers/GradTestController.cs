using Microsoft.AspNetCore.Authorization;
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
    public class GradTestController : ControllerBase
    {
        private readonly IGradService _service;

        public GradTestController(IGradService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public List<OnlineGym_Model.Gradovi> Get()
        {
            return _service.Get();
        }
    }
}
