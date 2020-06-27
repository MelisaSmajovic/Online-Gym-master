using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public interface IClanTeretanaService
    {
        List<OnlineGym_Model.ClanTeretana> Get();
        OnlineGym_Model.ClanTeretana Insert(ClanTeretanaUpsertRequest request);
    }
}
