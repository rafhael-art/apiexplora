using Dapper;
using System.Data;
using Xplora.Model.Entities;
using Xplora.Persistence.Database.Context;
using Xplora.Services.Interfaces;

namespace Xplora.Services.Services
{
  public class ProductRepository : GenericRepository<Products>, IProductRepository
  {
    private readonly AplicationDbContext _context;
    public ProductRepository(AplicationDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Products>> FindByName(object param)
    {
      using var connection = _context.CreateConnection;
      return await connection.QueryAsync<Products>("USP_PRODUCT_FIND_BY_NAME", param: param, commandType: CommandType.StoredProcedure);
    }
  }
}

