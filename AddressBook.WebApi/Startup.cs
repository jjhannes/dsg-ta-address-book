using AddressBook.Data;
using AddressBook.Api.Middelware;
using AddressBook.Api.Services;
using AddressBook.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace AddressBook
{
    public class Startup
    {
        public IConfiguration _config { get; }

        public Startup(IConfiguration config)
        {
            this._config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AddressBookDBContext>();
            services.AddScoped<IUsersRepo, Data.Repos.Mock.UserRepo>();
            services.AddScoped<IClientRepo, Data.Repos.Mock.ClientRepo>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.Configure<AppSettings>(this._config.GetSection("AppSettings"));

            services.AddTransient(typeof(AuthService));

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AddressBook", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AddressBook v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<JWT>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
