using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlternateApprochDi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AlternateApprochDi", Version = "v1" });
            });

            services.AddSingleton<XTool>();
            services.AddSingleton<YTool>();
            services.AddSingleton<ATool>();
            services.AddSingleton<BTool>();
            services.AddSingleton<ToolFactory>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlternateApprochDi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public interface ITool
    {
        public string Process(string input);
    }

    public class ATool : ITool
    {

        public string Process(string input)
        {
            return "atool" + input + "some asdfaf";
        }
    }

    public class BTool : ITool
    {

        public string Process(string input)
        {
            return "btool" + input + "some b";
        }
    }

    public class XTool : ITool
    {

        public string Process(string input)
        {
            return "xtool" + input + "some sfdafs";
        }
    }

    public class YTool : ITool
    {

        public string Process(string input)
        {
            return "ytool" + input + "some yysts";
        }
    }


    public class ToolFactory
    {
        private readonly IServiceProvider sp;

        public ToolFactory(IServiceProvider sp)
        {
            this.sp = sp;
        }

        public ITool GetTool(string s)
        {
            switch (s) 
            {
                case "xtool": return sp.GetService<XTool>();
                case "ytool": return sp.GetService<YTool>();
                case "atool": return sp.GetService<ATool>();
                case "btool": return sp.GetService<BTool>();
                default : throw new NotImplementedException();
            }
        }
    }

}
