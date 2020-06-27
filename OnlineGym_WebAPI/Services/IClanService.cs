using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public interface IClanService
    {
        List<OnlineGym_Model.Clan> Get(ClanSearchRequest request);

        OnlineGym_Model.Clan GetById(int id);

        OnlineGym_Model.Clan Insert(ClanUpsertRequest request);

        OnlineGym_Model.Clan Update(int id, ClanUpsertRequest request);
        OnlineGym_Model.Clan Authenticiraj(string username, string pass);
    }
}
