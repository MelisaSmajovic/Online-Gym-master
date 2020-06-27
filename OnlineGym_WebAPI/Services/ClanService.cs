using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineGym_WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OnlineGym_WebAPI.Services;
using OnlineGym_Model.Requests;

namespace OnlineGym_WebAPI.Services
{
    public class ClanService:IClanService
    {
        private readonly DB_TeretanaContext _context;
        private readonly IMapper _mapper;
        public ClanService(DB_TeretanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OnlineGym_Model.Clan Authenticiraj(string username, string pass)
        {
            var user = _context.Clan.FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<OnlineGym_Model.Clan>(user);
                }
            }
            return null;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }


        public List<OnlineGym_Model.Clan> Get(ClanSearchRequest request)
        {
            var query = _context.Set<Database.Clan>().Include(c => c.Grad).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime) || x.Prezime.StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }
            if (!string.IsNullOrWhiteSpace(request?.Username))
            {
                query = query.Where(x =>(String.Equals(x.KorisnickoIme, request.Username)));
            }
            query = query.OrderBy(x => x.KorisnickoIme);
            var list = query.ToList();

            return _mapper.Map<List<OnlineGym_Model.Clan>>(list);
        }

        public OnlineGym_Model.Clan GetById(int id)
        {
            var entity = _context.Clan.Find(id);

            return _mapper.Map<OnlineGym_Model.Clan>(entity);
        }

        public OnlineGym_Model.Clan Insert(ClanUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Clan>(request); 

            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            var count = _context.Clan.Count(x => x.KorisnickoIme.Equals(request.KorisnickoIme));

            if(count > 0)
                throw new Exception("Korisničko ime je već zauzeto. Odaberite drugo!");


            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Clan.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<OnlineGym_Model.Clan>(entity);
        }

        public OnlineGym_Model.Clan Update(int id, ClanUpsertRequest request)
        {
            var user = _context.Clan.FirstOrDefault(x => x.ClanId == id);

            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, request.StariPassword);

                if (newHash != user.LozinkaHash)
                {
                    throw new Exception("Unesite ispravnu staru lozinku!");
                }
                else
                {
                    var entity = _context.Clan.Find(id);
                    _context.Clan.Attach(entity);
                    _context.Clan.Update(entity);

                    if (!string.IsNullOrWhiteSpace(request.Password))
                    {
                        if (request.Password != request.PasswordPotvrda)
                        {
                            throw new Exception("Passwordi se ne slažu");
                        }

                        entity.LozinkaSalt = GenerateSalt();
                        entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
                    }

                    _mapper.Map(request, entity);

                    _context.SaveChanges();

                    return _mapper.Map<OnlineGym_Model.Clan>(entity);


                }

            }

            return null;

        }

    }
}
