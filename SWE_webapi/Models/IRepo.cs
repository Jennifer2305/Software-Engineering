using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SWE_webapi.Models
{
    public interface IRepo
    {
        public IQueryable<Book> Books { get; }

        public IQueryable<Author> Authors { get; }

        void Add<Entitytype>(Entitytype entity);
        void SaveChanges();

    }
}
