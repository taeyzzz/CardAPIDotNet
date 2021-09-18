using System.Text;
using System.Text.Json;
using Application.Services.Cards;
using Application.Services.Users;
using CardApi.Middlewares.Error;
using CardApi.Middlewares.Jwt;
using CardApi.Services.Cookie;
using CardApi.Services.Jwt;
using Domain.Interfaces;
using Infrastructure.DBContext;
using Infrastructure.Repositories.Card;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace CardApi
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

            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    // config response to be camel case
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                // handle validate model in request and return bad request response               
                options.InvalidModelStateResponseFactory = actionContext => new BadRequestObjectResult(actionContext.ModelState);
            });
            
            services.AddDbContext<AppDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DBConfiguration")));
            
            //IHttpContextAccessor register
            services.AddHttpContextAccessor();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddSingleton<IJwtService, JwtTokenService>();
            services.AddSingleton<ICookieService, CookieService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CardApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CardApi v1"));
            }

            app.UseSerilogRequestLogging();

            ConfigureMiddlewares(app);

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureMiddlewares(IApplicationBuilder app)
        {
            app.ConfigureExceptionMiddleware();
            app.ConfigureJwtMiddleware();
        }
    }
}
