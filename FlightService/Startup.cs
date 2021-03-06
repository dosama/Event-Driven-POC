﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightService.Data;
using FlightService.Messaging;
using FlightService.Repositories.Bookings;
using FlightService.Repositories.MessageLogs;
using FlightService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FlightService
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
            services.AddDbContext<FlightContext>
                (options => options.UseSqlServer(Configuration["DBConnectionString"]), ServiceLifetime.Singleton);

            services.AddSingleton<IFlightBookingService, FlightBookingService>();
            services.AddSingleton<IMessageLogsRepository, MessageLogsRepository>();
            services.AddSingleton<IBookingRepository, BookingRepository>();
            services.AddSingleton<IFlightEventHandler, FlightEventHandler>();
            services.AddSingleton<IFlightEventProducer, FlightEventProducer>();
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
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
