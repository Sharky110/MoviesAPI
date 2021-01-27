using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Movies.Core;
using Movies.Data;
using Microsoft.EntityFrameworkCore;
using Movies.Services;
using Movies.Core.Services;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System;

namespace Movies.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("MoviesApi"), x => x.MigrationsAssembly("Movies.Data"));
                options.LogTo(Console.WriteLine);
            });

            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IGenreService, GenreService>();

            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "My Movies", Version = "v1" }));

            services.AddAutoMapper(typeof(Startup));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Movies V1");
            });
            //if (env.IsDevelopment())
            //    app.UseDeveloperExceptionPage();


            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.RoutePrefix = "";
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Movies V1");
            //});
        }
    }
}
