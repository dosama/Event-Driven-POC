using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderServiceApi.Data;
using OrderServiceApi.Messaging;
using OrderServiceApi.Repositories.MessageLogs;
using OrderServiceApi.Repositories.Order;
using OrderServiceApi.Service;
using OrderServiceApi.SMS;

namespace OrderServiceApi
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

            services.AddDbContext<OrderContext>
                (options => options.UseSqlServer(Configuration["DBConnectionString"]), ServiceLifetime.Singleton);

            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IMessageLogsRepository, MessageLogsRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderEventHandler, OrderEventHandler>();
            services.AddSingleton<IOrderEventProducer, OrderEventProducer>();
            services.AddSingleton<IKafkaService, KafkaService>();
            services.AddSingleton<IMessageSerializer, MessageSelrializer>();
            services.AddSingleton<ISmsService, SmsService>();
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
