using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GambitGraph.Common.Repository;
using GambitGraph.Core;
using GambitGraph.Core.Mutations;
using GambitGraph.Core.Queries;
using GambitGraph.Core.Types;
using GambitGraph.DataAccess;
using GambitGraph.Repository;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GambitGraph.API
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
            services.AddControllers().AddNewtonsoftJson(options => 
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddTransient<ISpellRepository, SpellRepository>();
            services.AddDbContext<Gambitbot13Context>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            // GraphQL
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<SpellQuery>();
            services.AddSingleton<SpellMutation>();
            services.AddSingleton<SpellInputType>();
            services.AddSingleton<SpellType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GambitGraphSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();

         //   app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
