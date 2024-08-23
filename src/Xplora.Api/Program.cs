using Serilog;
using System.Reflection;
using Xplora.Persistence.Database.Extensions;
using Xplora.Services.Extensions;
using Xplora.UseCases.Extensions;

var builder = WebApplication.CreateBuilder(args);

var Cors = "Cors";

builder.Host.UseSerilog((context, services, configuration) => configuration
    .WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
 
builder.Services.AddSwaggerGen(c =>
{
  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  c.IncludeXmlComments(xmlPath);
});

builder.Services.AddInjectionUseCase();

builder.Services.AddInjectionPersistence();

builder.Services.AddInjectionServices();

builder.Services.AddInjectionPersistence();

builder.Services.AddCors(options => options.AddPolicy(Cors,
                                    builder => builder
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .SetIsOriginAllowed(origin => true)
                                    .AllowCredentials()
                                    ));

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseCors(Cors);

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

