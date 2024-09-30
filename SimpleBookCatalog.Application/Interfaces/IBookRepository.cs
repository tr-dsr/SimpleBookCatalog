using SimpleBookCatalog.Domain.Entities;

namespace SimpleBookCatalog.Application.Interfaces
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);
        Task<List<Book>> GetAllBooksList();
        Task<Book?> GetBookByIdAsync(int Id);
        Task UpdateAsync(Book book);
        Task DeleteBookByIdAsync(int Id);
    }
}
 