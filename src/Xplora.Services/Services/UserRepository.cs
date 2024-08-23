using Dapper;
using System.Data;
using Xplora.Model.Entities;
using Xplora.Persistence.Database.Context;
using Xplora.Services.Interfaces;
namespace Xplora.Services.Services
{
  public class UserRepository : GenericRepository<Users>, IUserRepository
  {
    private readonly AplicationDbContext _context;
    public UserRepository(AplicationDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<Users?> GetByEmail(string email)
    {
      using var connection = _context.CreateConnection;
      DynamicParameters parameter = new DynamicParameters();
      parameter.Add("@Email", email);
      return await connection.QuerySingleOrDefaultAsync<Users>("USP_USER_GET_BY_EMAIL", parameter, commandType: CommandType.StoredProcedure);
    }
  }
}

