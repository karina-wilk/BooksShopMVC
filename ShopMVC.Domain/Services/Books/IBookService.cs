﻿using ShopMVC.Domain.DAL;
using ShopMVC.Domain.Entities;
using ShopMVC.Domain.Interfaces;
using ShopMVC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Services.Books
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetListAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> GetByIdFullDataAsync(int id);
        void Update(Book item);
        Task DeleteAsync(int id);
        void Add(Book item);

        Task<IEnumerable<BookCategory>> GetCategoriesAsync();
    }
}