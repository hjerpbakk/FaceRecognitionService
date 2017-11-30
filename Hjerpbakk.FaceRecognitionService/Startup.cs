using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hjerpbakk.FaceRecognitionService.Clients;
using Hjerpbakk.FaceRecognitionService.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.ProjectOxford.Face;
using Newtonsoft.Json;

namespace Hjerpbakk.FaceRecognitionService
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
            services.AddMvc();

            var configuration = ReadConfig();
            configuration.Delay = TimeSpan.FromMilliseconds(600D);
            services.AddSingleton<IFaceRecognitionConfiguration>(configuration);
            services.AddSingleton<IFaceServiceClient>(new FaceServiceClient(configuration.Key, configuration.URL));
            services.AddSingleton<IFaceRecognitionClient, FaceRecognitionClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
        }

        static FaceRecognitionConfiguration ReadConfig()
        {
            return JsonConvert.DeserializeObject<FaceRecognitionConfiguration>(File.ReadAllText("config.json"));
        }
    }
}
