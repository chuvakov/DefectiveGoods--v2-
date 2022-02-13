using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DefectiveGoods.Core;
using DefectiveGoods.Core.Branches;
using DefectiveGoods.Core.Infrastructure.Repositories;
using DefectiveGoods.Core.Products;
using DefectiveGoods.Core.Users;
using DefectiveGoods.EntityFrameworkCore;
using DefectiveGoods.EntityFrameworkCore.Repositories;
using DefectiveGoods.EntityFrameworkCore.Repositories.Users;
using DefectiveGoods.Mvc.Mapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DefectiveGoods.Mvc
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
            string connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<DefectiveGoodsContext>(options => options.UseNpgsql(connectionString));

            // Установка конфигурации аутентификации(аутентификация на основе coocke)
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            // Automapper - конфигурация 
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ViewModelToEntityProfile());
                mc.AddProfile(new EntityToDtoProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            // Внедрение зависимостей
            services.AddSingleton(mapper);            
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRepository<Branch, int>, EfRepositoryBase<DefectiveGoodsContext, Branch, int>>();
            services.AddTransient<IRepository<Product, long>, EfRepositoryBase<DefectiveGoodsContext, Product, long>>();

            services.AddControllersWithViews();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

