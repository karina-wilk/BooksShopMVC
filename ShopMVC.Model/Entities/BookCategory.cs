using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Model.Entities
{
    public class BookCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }

        public BookCategory()
        {
            Books = new List<Book>();
        }
    }
}
