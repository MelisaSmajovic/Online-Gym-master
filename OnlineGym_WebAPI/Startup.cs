using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnlineGym_WebAPI.Database;
using OnlineGym_WebAPI.Filters;
using OnlineGym_WebAPI.Security;
using OnlineGym_WebAPI.Services;
using OnlineGym_Model.Requests;

namespace OnlineGym_WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => {
                x.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }, ArrayPool<char>.Shared));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(Startup));
            services.AddAuthentication("BasicAuthentication")
              .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IProizvodTestService, ProizvodTestService>();
            services.AddScoped<IClanService, ClanService>();
            services.AddScoped<IGradService, GradService>();
            services.AddScoped<INarudzbaService, NarudzbaService>();
            services.AddScoped<INarudzbaStavkaService, NarudzbaStavkaService>();
            services.AddScoped<IIzlazService, Izlazservice>();
            services.AddScoped<ISistemPreporukeProizvodi, SistemPreporukeProizvodi>();
            services.AddScoped<ISistemPreporukeTeretane, SistemPreporukeTeretane>();


            services.AddScoped<IService<OnlineGym_Model.KategorijeProizvoda, object>, BaseService<OnlineGym_Model.KategorijeProizvoda, object, KategorijaProizvoda>>();
            services.AddScoped<IService<OnlineGym_Model.VrsteProizvoda, object>, BaseService<OnlineGym_Model.VrsteProizvoda, object, VrstaProizvoda>>();
            services.AddScoped<IService<OnlineGym_Model.Gradovi, object>, BaseService<OnlineGym_Model.Gradovi, object, Grad>>();
            services.AddScoped<IService<OnlineGym_Model.Uloga, object>, BaseService<OnlineGym_Model.Uloga, object, Uloga>>();
            services.AddScoped<IService<OnlineGym_Model.TipClanarine, object>, BaseService<OnlineGym_Model.TipClanarine, object, TipClanarine>>();
            services.AddScoped<ICRUDService<OnlineGym_Model.Proizvod, ProizvodSearchRequest, ProizvodUpsertRequest, ProizvodUpsertRequest>, ProizvodService>();
            services.AddScoped<ICRUDService<OnlineGym_Model.Teretana, TeretanaSearchRequest, TeretanaUpsertRequest, TeretanaUpsertRequest>, TeretanaService>();    
            services.AddScoped<ICRUDService<OnlineGym_Model.ClanTeretana, ClanTeretanaSearchRequest, ClanTeretanaUpsertRequest, ClanTeretanaUpsertRequest>, ClanTeretanaService>();
            services.AddScoped<ICRUDService<OnlineGym_Model.PlacanjeClanarine, PlacanjeClanarineSearchRequest, PlacanjeClanarineUpsertRequest, PlacanjeClanarineUpsertRequest>, PlacanjeClanarineService>();
            services.AddScoped<ICRUDService<OnlineGym_Model.KorisnikUloge, KorisnikUlogaSearchRequest, KorisnikUlogaUpsertRequest, KorisnikUlogaUpsertRequest>, KorisnikUlogeService>();
            services.AddScoped<ICRUDService<OnlineGym_Model.RecenzijeProizvoda, RecenzijeProizvodaSearchRequest, RecenzijeProizvodaUpsertRequest, RecenzijeProizvodaUpsertRequest>, RecenzijeProizvodaService>();
            services.AddScoped<ICRUDService<OnlineGym_Model.RecenzijeTeretane, RecenzijeTeretaneSearchRequest, RecenzijeTeretaneUpsertRequest, RecenzijeTeretaneUpsertRequest>, RecenzijeTeretaneService>();        
            services.AddScoped<ICRUDService<OnlineGym_Model.Obavijest, ObavijestSearchRequest, ObavijestUpsertRequest, ObavijestUpsertRequest>, ObavijestService>();

            var connection = @"data source=.;initial catalog=160158;integrated security = True";
            //var connection = @"Server=.;Database=160158;Trusted_Connection=true;ConnectRetryCount=0";
            //a.data source =.; initial catalog = brojIndeksa; integrated security = True;
            services.AddDbContext<DB_TeretanaContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
