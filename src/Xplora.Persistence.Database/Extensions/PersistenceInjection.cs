using Microsoft.Extensions.DependencyInjection;
using Xplora.Persistence.Database.Context;

namespace Xplora.Persistence.Database.Extensions
{
  public static class PersistenceInjection
  {
    public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
    {
      services.AddSingleton<AplicationDbContext>();
      return services;
    }
  }
}

