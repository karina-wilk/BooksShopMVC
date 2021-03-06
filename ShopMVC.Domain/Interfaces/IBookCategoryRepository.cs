﻿using ShopMVC.Domain.Entities;
using ShopMVC.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Domain.Interfaces
{
    public interface IBookCategoryRepository
    {
        Task<IEnumerable<BookCategory>> GetList();
    }
}
