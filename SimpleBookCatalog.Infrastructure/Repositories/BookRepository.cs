using SimpleBookCatalog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Infrastructure.Context;
using SimpleBookCatalog.Domain.Entities;

namespace SimpleBookCatalog.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SimpleBookCatalogDbContext context;

        public BookRepository(IDbContextFactory<SimpleBookCatalogDbContext> factory)
        { 
            context = factory.CreateDbContext();
        }

        public async Task AddAsync(Book book)
        {
            try
            {
                context.Books.Add(book);
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
        }

        public async Task<List<Book>> GetAllBooksList()
        {
            var books =  await context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetBookByIdAsync(int Id)
        {
            var book = await context.Books.FirstOrDefaultAsync(e => e.Id == Id);
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteBookByIdAsync(int Id)
        {
            var book = await GetBookByIdAsync(Id);
            if(book is not null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }
    }
}
