using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TwitchWebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IRedisClient, RedisClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }

    public interface IRedisClient
    {
        StackExchange.Redis.ConnectionMultiplexer RedisServer { get; set; }
    }

    public class RedisClient : IRedisClient
    {
        public RedisClient()
        {
            try{
                RedisServer = StackExchange.Redis.ConnectionMultiplexer.Connect("localhost");
            }
            catch{
                Console.WriteLine("Redis failed to connect");
            }
        }
        public StackExchange.Redis.ConnectionMultiplexer RedisServer { get; set; }
    }
}
