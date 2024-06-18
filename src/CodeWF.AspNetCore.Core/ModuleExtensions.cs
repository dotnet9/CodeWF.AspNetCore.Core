using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeWF.AspNetCore.Core
{
    public static class ModuleExtensions
    {
        private static readonly List<IModule> Modules = new();

        public static IServiceCollection AddModules(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var asm in assemblies)
            {
                var types = asm.GetTypes();
                var moduleTypes = types.Where(t => !t.IsAbstract && typeof(IModule).IsAssignableFrom(t));
                foreach (var moduleType in moduleTypes)
                {
                    if (Activator.CreateInstance(moduleType) is not IModule module)
                    {
                        throw new ApplicationException($"Cannot create ${moduleType}");
                    }

                    module.ConfigureServices(services);
                    Modules.Add(module);
                }
            }

            return services;
        }

        public static void UseModules(this IApplicationBuilder app)
        {
            foreach (var module in Modules)
            {
                module.Configure(app);
            }
        }
    }
}