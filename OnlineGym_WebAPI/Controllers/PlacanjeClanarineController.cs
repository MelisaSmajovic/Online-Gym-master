using OnlineGym_WebAPI.Services;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Controllers
{
    public class PlacanjeClanarineController : BaseCRUDController<OnlineGym_Model.PlacanjeClanarine, PlacanjeClanarineSearchRequest, PlacanjeClanarineUpsertRequest, PlacanjeClanarineUpsertRequest>
    {
        public PlacanjeClanarineController(ICRUDService<OnlineGym_Model.PlacanjeClanarine, PlacanjeClanarineSearchRequest, PlacanjeClanarineUpsertRequest, PlacanjeClanarineUpsertRequest> service) : base(service)
        {
        }
    }
}
