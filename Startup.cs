using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using New_Portal_Web_API.Repository;
using New_Portal_Web_API.DAL;

namespace New_Portal_Web_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Startup(INewsRepository newsRepository, ICategoryRepository categoryRepository, ICityRepository cityRepository)
        {
            NewsRepository = newsRepository;
            CategoryRepository = categoryRepository;
            CityRepository = cityRepository;
        }

        public INewsRepository NewsRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public ICityRepository CityRepository { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseDb>(options =>
            options.UseMySql(Configuration.GetConnectionString("JornalDb"))
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    
            services.AddSingleton<INewsRepository, NewsRepository>();

            services.AddSingleton<ICategoryRepository, CategoryRepository>();

            services.AddSingleton<ICityRepository, CityRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
