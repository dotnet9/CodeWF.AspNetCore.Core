# CodeWF.AspNetCore.Core

一个简易的ASP.NET Core核心库，支持模块化开发。

安装NuGet包：

```shell
NuGet\Install-Package CodeWF.AspNetCore.Core -Version 1.0.0
```

创建模块类库，添加模块入口类：

```csharp
public class SampleModule : IModule
{
    public void ConfigureServices(IServiceCollection services)
    {
    }

    public void Configure(IApplicationBuilder app)
    {
    }
}
```

注入模块：

```csharp
using CodeWF.AspNetCore.Core;
using WebAPISample.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var moduleAssemblies = FileHelper.GetModuleAssemblies();
builder.Services.AddModules(moduleAssemblies);

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.UseModules();

app.Run();
```

读取模块工程程序集

```csharp
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
```

