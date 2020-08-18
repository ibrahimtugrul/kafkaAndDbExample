using KafkaDbPairProject.Domain.Service;
using KafkaDbPairProject.Domain.Data;
using KafkaDbPairProject.Domain.Repository;
using KafkaDbPairProject.domain.service;
using KafkaDbPairProject.Domain.Service.Consumers;
using KafkaDbPairProject.Domain.Service.Interfaces;
using KafkaDbPairProject.Domain.Service.Producers;
using KafkaDbPairProject.Domain.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KafkaDbPairProject
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
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    o => o.SetPostgresVersion(9, 6)));
            
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();

            services.AddScoped<IOrderLogRepository, OrderLogRepository>();

            services.AddSingleton<IOrderCreatedProducer, OrderCreatedProducer>();
            services.AddScoped<IOrderCreatedConsumer, OrderCreatedConsumer>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerConsumer, CustomerConsumer>();
            services.AddScoped<ICustomerProducer, CustomerProducer>();

            services.AddScoped<IOrderReceivedProducer, OrderReceivedProducer>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
