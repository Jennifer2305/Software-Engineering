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
        Func<Book, T> convertBook;
        Func<Author, T> convertAuthor;

        public List<Book> testList;

        public DBset(T type){
            this.Type = type;
        }

        //s => new { s.Name, s.Surname }

        public List<Book> Select<TResult>(Func<T, TResult> fun)
        {
            //var test = fun(Type);

            Book testje = Type as Book;

            using (var db = new LibraryContext(options))
            {   
                if (testje != null)
                {
                    var dbResult = from m in db.Books select m;
                    foreach (var entity in dbResult)
                    {
                        entities.Add(convertBook(entity));
                    }
                    return testList;
                }
                else
                {
                    var dbResult = from m in db.Books select m;
                    foreach (var entity in dbResult)
                    {
                        entities.Add(convertBook(entity));
                    }
                    return testList;
                }
                


                /*if (testje != null)
                {
                    var resultDB = from m in db.Books select m;
                    foreach (var entity in resultDB)
                    {
                        testList.Add(entity);
                  
                    }
                    return testList;
                }
                else
                {
                    var resultDB = from m in db.Authors select m;
                    foreach (var entity in resultDB)
                    {
                        entities.Add(convertAuthor(entity));
                    }
                }*/
            }
            
            
            //return null;

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

