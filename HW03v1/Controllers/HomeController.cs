using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using HW03v1.Models;

namespace HW03v1.Controllers
{
    public class HomeController : Controller
    {
        private LibraryEntities1 db = new LibraryEntities1();

        // Home page
        public ActionResult Index(int? page)
        {
            int pageSize = 20; 
            int pageNumber = (page ?? 1); 

            var viewModel = new CombinedViewModel
            {
                authorList = db.authors.ToList(),
                borrowsList = db.borrows.ToList(),
                typesList = db.types.ToList(),
            };

            // Pagination for the studentsList
            var studentsList = db.students.OrderBy(s => s.studentId);
            var studentsPaged = studentsList.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            ViewBag.TotalStudentPages = (int)Math.Ceiling((double)studentsList.Count() / pageSize);
            ViewBag.CurrentStudentPage = pageNumber;

            viewModel.studentsList = studentsPaged.ToList();

            // Pagination for the bookList
            var bookList = db.books.Include("authors").Include("types").OrderBy(b => b.bookId);
            var bookPaged = bookList.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            ViewBag.TotalBookPages = (int)Math.Ceiling((double)bookList.Count() / pageSize);
            ViewBag.CurrentBookPage = pageNumber;

            viewModel.bookList = bookPaged.ToList();

            return View(viewModel);
        }

        // Maintain page
        public ActionResult About(int? authorPage, int? borrowPage, int? typesPage)
        {
            int pageSize = 15;

            int borrowPageNum = borrowPage ?? 1;
            int authorPageNum = authorPage ?? 1;            
            int typesPageNum = typesPage ?? 1;

            var viewModel = new CombinedViewModel
            {
                authorList = db.authors.ToList().Skip((authorPageNum - 1) * pageSize).Take(pageSize).ToList(),
                borrowsList = db.borrows.ToList().Skip((borrowPageNum - 1) * pageSize).Take(pageSize).ToList(),
                typesList = db.types.ToList().Skip((typesPageNum - 1) * pageSize).Take(pageSize).ToList()
            };

            ViewBag.TotalAuthorPages = (int)Math.Ceiling((double)db.authors.Count() / pageSize);
            ViewBag.CurrentAuthorPage = authorPageNum;

            ViewBag.TotalBorrowPages = (int)Math.Ceiling((double)db.borrows.Count() / pageSize);
            ViewBag.CurrentBorrowPage = borrowPageNum;

            ViewBag.TotalTypesPages = (int)Math.Ceiling((double)db.types.Count() / pageSize);
            ViewBag.CurrentTypesPage = typesPageNum;

            return View(viewModel);
        }

        // Report page
        public ActionResult Contact( string filename, string fileType)
        {   
            return View();
        }
        
    }
}