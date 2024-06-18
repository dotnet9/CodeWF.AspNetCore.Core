using CodeWF.AspNetCore.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SampleModule.Services;

namespace SampleModule
{
    public class SampleModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITimeService, TimeService>();
        }

        public void Configure(IApplicationBuilder app)
        {
        }
    }
}