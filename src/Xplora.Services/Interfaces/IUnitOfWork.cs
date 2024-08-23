using System.Transactions;

namespace Xplora.Services.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    IUserRepository UserRepository { get; }
    IProductRepository ProductRepository { get; }
    TransactionScope BeginTransaction();
  }
}

