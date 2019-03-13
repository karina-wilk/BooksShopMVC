using ShopMVC.Domain.Entities;
using ShopMVC.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetListAsync();
        Task<IEnumerable<Book>> GetListOfBestsellingAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> GetByIdFullDataAsync(int id);
        void Update(Book item);
        Task DeleteAsync(int id);
        void Add(Book item);
        Task SaveAsync();
    }
}
