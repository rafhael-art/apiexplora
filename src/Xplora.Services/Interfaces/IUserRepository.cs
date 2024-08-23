using Xplora.Model.Entities;

namespace Xplora.Services.Interfaces
{
  public interface IUserRepository : IGenericRepository<Users>
  {
    Task<Users?> GetByEmail(string email);
  }
}

