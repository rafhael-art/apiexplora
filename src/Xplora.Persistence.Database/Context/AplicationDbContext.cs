using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Xplora.Persistence.Database.Context
{
  public class AplicationDbContext
  {
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public AplicationDbContext(IConfiguration configuration)
    {
      _configuration = configuration;
      _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
    }

    public IDbConnection CreateConnection => new SqlConnection(_connectionString);
  }
}

