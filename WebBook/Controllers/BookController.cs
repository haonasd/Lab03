using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBook.Models;

namespace WebBook.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        //Code them
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include="Id,Title,Author,Image_cover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Đạo tình", "Chu Ngọc", "/Images/daotinh.jpg"));
            books.Add(new Book(2, "Tây xuất ngọc môn", "Vĩ Ngư", "/Images/tayxuatngocmon.jpg"));
            books.Add(new Book(3, "Mười hai năm, kịch cố nhân", "Mặc Bảo Phi Bảo", "/Images/muoihainam.jpg"));
            try
            {
                if(ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch(RetryLimitExceededException )
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        
        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title,string Author,string Image_cover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Đạo tình", "Chu Ngọc", "/Images/daotinh.jpg"));
            books.Add(new Book(2, "Tây xuất ngọc môn", "Vĩ Ngư", "/Images/tayxuatngocmon.jpg"));
            books.Add(new Book(3, "Mười hai năm, kịch cố nhân", "Mặc Bảo Phi Bảo", "/Images/muoihainam.jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach(Book b in books)
            {
                if(b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = Image_cover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Đạo tình", "Chu Ngọc", "/Images/daotinh.jpg"));
            books.Add(new Book(2, "Tây xuất ngọc môn", "Vĩ Ngư", "/Images/tayxuatngocmon.jpg"));
            books.Add(new Book(3, "Mười hai năm, kịch cố nhân", "Mặc Bảo Phi Bảo", "/Images/muoihainam.jpg"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if(b.Id==id)
                {
                    book = b;
                    break;
                }
            }
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Index()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Đạo tình", "Chu Ngọc", "/Images/daotinh.jpg"));
            books.Add(new Book(2, "Tây xuất ngọc môn", "Vĩ Ngư", "/Images/tayxuatngocmon.jpg"));
            books.Add(new Book(3, "Mười hai năm, kịch cố nhân", "Mặc Bảo Phi Bảo", "/Images/muoihainam.jpg"));
            books.Add(new Book(4, "Dụ tình", "Ân Tầm", "/Images/dutinh.jpg"));
            books.Add(new Book(5, "Khách sạn hoàng tuyền", "Cố Mạn", "/Images/khachsanhoangtuyen.jpg"));
            books.Add(new Book(6, "Không thể quay lại", "Diệp Lạc Vô Tâm", "/Images/time.png"));
            ViewBag.Books = books;
            return View(books);
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS3 Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC 5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Đạo tình", "Chu Ngọc", "./Images/daotinh.jpg"));
            books.Add(new Book(2, "Tây xuất ngọc môn", "Vĩ Ngư", "./Images/tayxuatngocmon.jpg"));
            books.Add(new Book(3, "Mười hai năm, kịch cố nhân", "Mặc Bảo Phi Bảo", "./Images/muoihainam.jpg"));
            ViewBag.Books = books;
            return View(books);
        }
    }
}