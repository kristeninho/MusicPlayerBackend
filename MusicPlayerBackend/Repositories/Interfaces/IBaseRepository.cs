namespace MusicPlayerBackend.Repositories.Interfaces
{
	public interface IBaseRepository<T>
	{
		Task<(string, string)?> AddAsync(T entity);
		Task<T?> UpdateAsync(T entity);
		Task<string> DeleteAsync(string entity);
	}
}
