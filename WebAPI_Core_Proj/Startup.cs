using DataAccessLayer_Entity_Framwork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjectModels.ViewModels;
using WebAPI_Core_Proj.Filters;

namespace WebAPI_Core_Proj
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI_Core_Proj", Version = "v1" });
            });

            //註冊appsetting
            services.Configure<ConfigViewModel>(Configuration.GetSection("Configurations"));
            //註冊EF的DbContext
            services.AddDbContext<Proj_DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefualtConnectStr")));
            //註冊Filter
            services.AddMvc(config =>
            {
                //config.Filters.Add(new ExceptionFilter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Proj_DBContext proj_DbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI_Core_Proj v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //執行前檢查資料庫是否被建立。
            proj_DbContext.Database.EnsureCreated();
        }
    }
}
