using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Services.Books
{
    public class BookService : IBookService
    {
        private BookUnityOfWork BookUoW = new BookUnityOfWork();

        public void Add(Book item)
        {
            BookUoW.BookRepo.Add(item);
        }

        public async Task DeleteAsync(int id)
        {
            await BookUoW.BookRepo.DeleteAsync(id);
            BookUoW.Save();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await BookUoW.BookRepo.GetByIdAsync(id);
        }

        public async Task<Book> GetByIdFullDataAsync(int id)
        {
            return await BookUoW.BookRepo.GetByIdFullDataAsync(id);
        }

        public async Task<IEnumerable<Book>> GetListAsync()
        {
            return await BookUoW.BookRepo.GetListAsync();
        }

        public void Update(Book item)
        {
            BookUoW.BookRepo.Update(item);
            BookUoW.Save();
        }

        public async Task<IEnumerable<BookCategory>> GetCategoriesAsync()
        {
            return await BookUoW.BookCategoryRepo.GetList();
        }
    }
}
