using Alura_MVC.Repositories;
using Alura_MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Alura_MVC
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
            // AddTransient - Objetos transitórios são sempre diferentes; uma nova instância é fornecida cada vez que o objeto é solicitado.
            // AddScoped - Objetos com escopo são os mesmos em uma requisições, mas diferentes entre requisições diferentes.
            // AddSingleton - Objetos singleton são os mesmos para todas as requisições.

            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IDataSource, DataSource>();

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ICadastroRepository, CadastroRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Pedido}/{action=Carrossel}/{codigo?}");
            });

            serviceProvider.GetService<IDataSource>().InicializaBD();
        }
    }
}
