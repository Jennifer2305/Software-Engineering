using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SWE_webapi.Models
{
    public class DbRepo : IRepo
    {
        private readonly LibraryContext _db;

        public DbRepo(LibraryContext db)
        {
            _db = db;
        }

        public IQueryable<Book> Books => _db.Books;
        public IQueryable<Author> Authors => _db.Authors;

        public void Add<EntityType>(EntityType entity) => _db.Add(entity);
        public void SaveChanges() => _db.SaveChanges();
    }
}
