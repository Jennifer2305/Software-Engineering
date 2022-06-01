using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SWE_webapi.Models;
using System.Linq;

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
        public List<T> entities;
        public T Type;

        public DBset(T type){
            this.Type = type;
        }

        //s => new { s.Name, s.Surname }

        public DBset<T> Select<TResult>(Func<T, TResult> fun)
        {
            var test = fun(Type);
            
            var typing = Type.GetType();

            //Book testje = (Book)Convert.ChangeType(Type, typeof(Book));

            



            using (var db = new LibraryContext(options))
            {
                /*if (itemType.Equals(Book))
                {

                }
                var projected_movies = from m in db.Books select m;*/
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

