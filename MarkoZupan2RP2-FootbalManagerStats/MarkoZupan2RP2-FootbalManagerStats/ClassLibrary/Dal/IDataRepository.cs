using ClassLibrary.Models;

namespace ClassLibrary.Dal
{
    public interface IDataRepository<TEntity>
    {
        Task<List<TEntity>> GetAllFromApi(Gender gender, string? fifaCode = null);
        Task SaveEntityListToFile(List<TEntity> data, string filePath);
        Task<List<TEntity>> LoadEntityListFromFile(string filePath, Gender gender, string? fifaCode = null);
    }
}
