using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public interface IKorisniciService
    {
        List<OnlineGym_Model.Korisnik> Get(KorisniciSearchRequest request);

        OnlineGym_Model.Korisnik GetById(int id);

        OnlineGym_Model.Korisnik Insert(KorisniciInsertRequest request);

        OnlineGym_Model.Korisnik Update(int id, KorisniciInsertRequest request);

        OnlineGym_Model.Korisnik Authenticiraj(string username, string pass);
    }
}
