using firstMVCAppDemo.Data;
using firstMVCAppDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstMVCAppDemo.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var NewBook = new Books()
            {
                Author = model.Author,
                CreatedOn =DateTime.UtcNow,
                Description =model.Description,
                Title= model.Title,
                LanguageId = model.LanguageId,
                TotalPages =model.TotalPages.HasValue? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };
           await _context.Books.AddAsync(NewBook);
           await _context.SaveChangesAsync();

            return NewBook.Id;
        }
        public async Task<List<BookModel>> getAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks =await _context.Books.ToListAsync();
            if(allBooks?.Any()==true)
            {
                foreach(var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Description = book.Description,
                        Category = book.Category,
                        Id = book.Id,
                        Title = book.Title,
                        LanguageId = book.LanguageId,
                        Language = book.Language.Name, 
                        TotalPages = book.TotalPages
                    });;
                }
            }
            return books;
        }
        public async Task<BookModel> getBook(int id)
        {
            //Get the hard coded data
            //var book =await _context.Books.FindAsync(id);
            //if(book != null)
            //{
            //    var bookDetail= new BookModel()
            //    {
            //        Author = book.Author,
            //        Description = book.Description,
            //        Category = book.Category,
            //        Id = book.Id,
            //        Title = book.Title,
            //        LanguageId = book.LanguageId,
            //        Language = book.Language.Name,
            //        TotalPages = book.TotalPages
            //    };
            //    return bookDetail;
            //}
            return await _context.Books.Where(x => x.Id == id)
                    .Select(book => new BookModel()
                    {
                        Author = book.Author,
                          Description = book.Description,
                             Category = book.Category,
                               Id = book.Id,
                               Title = book.Title,
                            LanguageId = book.LanguageId,
                               Language = book.Language.Name,
                               TotalPages = book.TotalPages
                    }).FirstOrDefaultAsync();

           
          //  return dataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> searchBooks(string title,string author)
        {
            // pass the hardcoded data
            //return dataSource().Where(x => x.Title == title && x.Author == author).ToList();
            return null;            
        }

        //private List<BookModel> dataSource()
        //{
        //    return new List<BookModel>()
        //    {
        //        new BookModel() { Id=1,Title="MVC",Author="Nitish", Description="This is MVC description",Category="Programming",Language="English",TotalPages=189},
        //        new BookModel() { Id=2,Title="JAVA",Author="Priyanka",Description="This is JAVA description",Category="Concept",Language="English",TotalPages=289},
        //         new BookModel() { Id=3,Title="C#",Author="Hemangi",Description="This is C# description",Category="Developer",Language="Hindi",TotalPages=239},
        //    };
        //}
    }
}
