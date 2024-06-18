using CodeWF.AspNetCore.Core;
using CodeWF.AspNetCore.EventBus;
using WebAPISample.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var moduleAssemblies = FileHelper.GetModuleAssemblies();
builder.Services.AddEventBus(moduleAssemblies);
builder.Services.AddModules(moduleAssemblies);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseEventBus(moduleAssemblies);
app.UseModules();

app.Run();