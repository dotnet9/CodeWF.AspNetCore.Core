using CodeWF.AspNetCore.Core;
using System.Reflection;

namespace WebAPISample.Helpers
{
    public static class FileHelper
    {
        public static Assembly[] GetModuleAssemblies()
        {
            return Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), "*.dll")
                .Select(Assembly.LoadFrom).Where(
                    assembly =>
                        assembly.GetTypes().Any(type => !type.IsAbstract
                                                        && typeof(IModule).IsAssignableFrom(type))).ToArray();
        }
    }
}