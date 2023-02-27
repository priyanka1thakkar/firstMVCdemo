using firstMVCAppDemo.Models;
using firstMVCAppDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstMVCAppDemo.Controllers
{
    public class BookController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<ViewResult> getAllBooks()
        {
            //return "All Books";
            var data=await _bookRepository.getAllBooks();

            return View(data);
        }
        public async Task<ViewResult> getBook(int id)
        {
            //return $"Book with id: {id}";
            var data=await _bookRepository.getBook(id);
            return View(data);
        }
        public List<BookModel> searchBook(string bookName,string authorName)
        {
            // return $"Book with bookName: {bookName} & authorName :{authorName}";
            return _bookRepository.searchBooks(bookName, authorName);
        }
        public async Task<ViewResult> addNewBook(bool isSuccess = false,int bookId=0)
        {
            var model = new BookModel()
            {
                LanguageId = 2
            };
            // ViewBag.Language = new SelectList(GetLanguage(),"Id","Text");

            //Using SelectListGroup
            //var group1 = new SelectListGroup() { Name = "group1" };
            //var group2 = new SelectListGroup() { Name = "group2" };

            //Using SelectListItem
            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Hindi", Value="1"},
            //    new SelectListItem(){Text="English", Value="2"},
            //    new SelectListItem(){Text="Gujarati", Value="3"}
            //};
            ViewBag.Language =new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addNewBook(BookModel bookModel)
        {
            if(ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(addNewBook), new { isSuccess = true, bookId = id });
                }

            }
            ViewBag.Language =new SelectList(await _languageRepository.GetLanguages(),"Id","Name");
            //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            return View();
        }
        //private List<LanguageModel> GetLanguage()
        //{
        //    return new List<LanguageModel>()
        //    {
        //        new LanguageModel(){Id=1, Text="Hindi"},
        //        new LanguageModel(){Id=2, Text="English"},
        //        new LanguageModel(){Id=3, Text="Gujarati"},
        //    };
        //}
    }
}
