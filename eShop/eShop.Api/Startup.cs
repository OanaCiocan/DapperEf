using eShop.DataAccess.Dapper;
using eShop.DataAccess.EntityFramework;
using eShop.DataAccess.EntityFramework.Context;
using eShop.Domain;
using eShop.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Api
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
            services.AddMvc();
            // EF
           // services.AddDbContext<OnlineShopContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
           // services.AddTransient(typeof(IRepository<>), typeof(EFRepository<>));
            
            //Dapper
            services.AddTransient(typeof(IRepository<Product>), typeof(ProductRepository));
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
