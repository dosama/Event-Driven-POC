using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelService.Data;
using HotelService.Messaging;
using HotelService.Repositories.MessageLogs;
using HotelService.Repositories.Reservations;
using HotelService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HotelService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

           
            services.AddDbContext<HotelContext>
                (options => options.UseSqlServer(Configuration["DBConnectionString"]), ServiceLifetime.Singleton);

            services.AddSingleton<IHotelReservationService, HotelReservationService>();
            services.AddSingleton<IMessageLogsRepository, MessageLogsRepository>();
            services.AddSingleton<IReservationRepository, ReservationRepository>();
            services.AddSingleton<IHotelEventHandler, HotelEventHandler>();
            services.AddSingleton<IHotelEventProducer, HotelEventProducer>();
            services.AddSingleton<IKafkaService, KafkaService>();
            services.AddSingleton<IMessageSerializer, MessageSelrializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
