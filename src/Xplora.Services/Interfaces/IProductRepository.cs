using Xplora.Model.Entities;

namespace Xplora.Services.Interfaces
{
  public interface IProductRepository : IGenericRepository<Products>
  {
    public Task<IEnumerable<Products>> FindByName(object param);
  }
}

