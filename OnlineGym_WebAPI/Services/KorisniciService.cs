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
    public class KorisniciService : IKorisniciService
    {
        private readonly DB_TeretanaContext _context;
        private readonly IMapper _mapper;

        public KorisniciService(DB_TeretanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OnlineGym_Model.Korisnik Authenticiraj(string username, string pass)
        {
            var user = _context.Korisnik.Include("KorisniciUloge.Uloga").FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<OnlineGym_Model.Korisnik>(user);
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


        public List<OnlineGym_Model.Korisnik> Get(KorisniciSearchRequest request)
        {
            bool admin = false;
            var query = _context.Korisnik.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime) || x.Prezime.StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }

            if (!string.IsNullOrWhiteSpace(request?.KorisnickoIme))
            {
                query = query.Where(x => (String.Equals(x.KorisnickoIme, request.KorisnickoIme)));
            }

            if (request?.IsUlogeLoadingEnabled == true)
            {
                List<KorisniciUloge> uloge = _context.KorisniciUloge.Where(x => x.Uloga.Naziv.Equals("Administrator")).Include(x=>x.Korisnik).ToList();
                List<int> korisniciUloge = new List<int>();
                foreach (KorisniciUloge k in uloge) 
                { 
                    korisniciUloge.Add(k.KorisnikId);
                    if (k.Korisnik.KorisnickoIme ==request.KorisnickoIme )
                        admin = true;
                }

     


                query = query.Where(x => korisniciUloge.Contains(x.KorisnikId));
            }
                if ( request.AdminChecked==true && admin==false)
                    throw new Exception("Niste administrator sistema!Molimo Vas da se prijavite kao uposlenik/menadžer!");

            query = query.OrderBy(x => x.KorisnickoIme);
            var list = query.ToList();

            return _mapper.Map<List<OnlineGym_Model.Korisnik>>(list);

        }

        public OnlineGym_Model.Korisnik GetById(int id)
        {
            var entity = _context.Korisnik.Find(id);

            return _mapper.Map<OnlineGym_Model.Korisnik>(entity);
        }

        public OnlineGym_Model.Korisnik Insert(KorisniciInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnik>(request);

            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisnik.Add(entity);
            _context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.UlogaId = uloga;
                _context.KorisniciUloge.Add(korisniciUloge);
          
            }
            _context.SaveChanges();

            return _mapper.Map<OnlineGym_Model.Korisnik>(entity);
        }

        public OnlineGym_Model.Korisnik Update(int id, KorisniciInsertRequest request)
        {

            var query = _context.Set<Database.Korisnik>().Include(c => c.KorisniciUloge).AsQueryable();
            var entity = query.Where(x => x.KorisnikId == id).FirstOrDefault();
            var entityRequest = _mapper.Map<Database.Korisnik>(request);


            if (entity != null) 
            {
                if (request.StariPassword != null) 
                {
                    var newHash = GenerateHash(entity.LozinkaSalt, request.StariPassword);

                    if (newHash != entity.LozinkaHash)
                    {
                        return null;
                        //throw new Exception("Unesite ispravnu staru lozinku!");

                    }
                    else
                    {
                        _context.Korisnik.Attach(entity);
                        _context.Korisnik.Update(entity);                      

                        _context.SaveChanges();
               

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

                        return _mapper.Map<OnlineGym_Model.Korisnik>(entity);
                    }
                }
                else
                {
                    _context.Korisnik.Attach(entity);
                    _context.Korisnik.Update(entity);

                    foreach(var postojecaUloga in entity.KorisniciUloge)
                    {
                        _context.KorisniciUloge.Remove(postojecaUloga);
                       
                    }
                    _context.SaveChanges();


                    foreach (var novaUloga in request.Uloge)
                    {
                        Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                        korisniciUloge.KorisnikId = entity.KorisnikId;
                        korisniciUloge.UlogaId = novaUloga;
                        _context.KorisniciUloge.Add(korisniciUloge);
               
                    }
                    _context.SaveChanges();
                    _context.SaveChanges();

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

                    return _mapper.Map<OnlineGym_Model.Korisnik>(entity);
                }
            }
            return null;
        }
    }
}

