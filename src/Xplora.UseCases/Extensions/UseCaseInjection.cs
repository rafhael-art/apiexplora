using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Xplora.UseCases.Extensions
{
  public static class UseCaseInjection
  {
    public static IServiceCollection AddInjectionUseCase(this IServiceCollection services)
    {
      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      return services;
    }
  }
}

