using System.Transactions;
using Xplora.Persistence.Database.Context;
using Xplora.Services.Interfaces;

namespace Xplora.Services.Services
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly AplicationDbContext _connection;
    public UnitOfWork(AplicationDbContext connection)
    {
      _connection = connection;
      UserRepository = new UserRepository(_connection);
      ProductRepository = new ProductRepository(_connection);
    }

    public IUserRepository UserRepository { get; }
    public IProductRepository ProductRepository { get; }


    public TransactionScope BeginTransaction()
    {
      var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
      return transaction;
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}

