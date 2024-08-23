namespace Xplora.Services.Interfaces
{
  public interface IGenericRepository<T> where T : class
  {
    Task<IEnumerable<T>> GetAllAsync(string storeProcedure);
    Task<T> GetByIdAsync(string storeProcedure, object parameter);
    Task<bool> ExecAsync(string storeProcedure, object parameter);
    Task<int> InsertAsync(string storeProcedure, object parameter);
  }
}

