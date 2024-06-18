using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CodeWF.AspNetCore.Core
{
    public interface IModule
    {
        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationBuilder app);
    }
}