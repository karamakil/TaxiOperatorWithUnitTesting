using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaxiOperator.BLL.DAL;
using TaxiOperator.BLL.Interface;
using TaxiOperator.Services;

namespace TaxiOperator
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        #region Ctor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                      ValidateIssuer = false,
                      ValidateAudience = false,
                  };
              });

            services.AddDbContext<TaxiOperatorContext>(x =>
                x.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"))
                );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Data}/{action=GetRandom}/{id?}");
            //});
        }
    }
}
