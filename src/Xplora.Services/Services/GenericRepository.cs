using Dapper;
using System.Data;
using Xplora.Persistence.Database.Context;
using Xplora.Services.Interfaces;

namespace Xplora.Services.Services
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly AplicationDbContext _context;

    public GenericRepository(AplicationDbContext context)
    {
      _context = context;
    }

    public async Task<bool> ExecAsync(string storeProcedure, object parameter)
    {
      using var connection = _context.CreateConnection;
      var objParam = new DynamicParameters(parameter);
      var recordAffected = await connection.ExecuteAsync(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
      return recordAffected > 0;
    }

    public async Task<int> InsertAsync(string storeProcedure, object parameter)
    {
      using var connection = _context.CreateConnection;
      var objParam = new DynamicParameters(parameter);
      var id = await connection.ExecuteScalarAsync<int>(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
      return id;
    }

    public async Task<IEnumerable<T>> GetAllAsync(string storeProcedure)
    {
      using var connection = _context.CreateConnection;
      return await connection.QueryAsync<T>(storeProcedure, commandType: CommandType.StoredProcedure);
    }

    public async Task<T> GetByIdAsync(string storeProcedure, object parameter)
    {
      using var connection = _context.CreateConnection;
      var objParam = new DynamicParameters(parameter);
      return (await connection.QuerySingleOrDefaultAsync<T>(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure))!;
    }
  }
}

