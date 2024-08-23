using Microsoft.Extensions.DependencyInjection;
using Xplora.Services.Interfaces;
using Xplora.Services.Services;

namespace Xplora.Services.Extensions
{
  public static class ServicesInjection
  {
    public static IServiceCollection AddInjectionServices(this IServiceCollection services)
    {
      services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      return services;
    }
  }
}

