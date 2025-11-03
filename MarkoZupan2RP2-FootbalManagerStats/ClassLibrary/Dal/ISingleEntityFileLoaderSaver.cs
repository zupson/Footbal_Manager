using ClassLibrary.Models;

namespace ClassLibrary.Dal
{
    public interface ISingleEntityFileLoaderSaver<TEntity>
    {
        Task SaveToFile(TEntity enitity, string filePath);
        Task<TEntity> LoadFromFile(string filePath);
    }
}
