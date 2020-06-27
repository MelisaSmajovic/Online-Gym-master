using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGym_WebAPI;
using OnlineGym_WebAPI.Services;
using OnlineGym_Model;
using OnlineGym_Model.Requests;

namespace OnlineGym_WebAPI.Controllers
{
    public class ProizvodController : BaseCRUDController<OnlineGym_Model.Proizvod, ProizvodSearchRequest, ProizvodUpsertRequest, ProizvodUpsertRequest>
    {
        public ProizvodController(ICRUDService<Proizvod, ProizvodSearchRequest, ProizvodUpsertRequest, ProizvodUpsertRequest> service) : base(service)
        {
        }
    }
}