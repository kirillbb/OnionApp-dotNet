using Microsoft.AspNetCore.Mvc;
using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;
using OnionApp.Services.Interfaces;

namespace OnionApp.Controllers
{
    public class HomeController : Controller
    {
        IBookRepository repository;
        IOrder order;

        public HomeController(IBookRepository repository, IOrder order)
        {
            this.repository = repository;
            this.order = order;
        }

        public ActionResult Index()
        {
            var books = repository.GetBookList();
            return View(books);
        }

        public ActionResult Buy(int id)
        {
            Book book = repository.GetBook(id);
            order.MakeOrder(book);
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}