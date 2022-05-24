using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SWE_webapi.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }



    }





    public class DBset<T>
    {
        DbContextOptions<LibraryContext> options = new DbContextOptionsBuilder<LibraryContext>().UseInMemoryDatabase(databaseName: "MyDb").Options;



        public DBset<T> Select(Func<T, List<T>> e)
        {
            using (var db = new LibraryContext(options))
            {
               
 
            }
            
            return null;

        }

        public DBset<T> Where(List<T> list)
        {

            foreach (T listcomponent in list)
            {
            }


            return null;

        }
    }
}

