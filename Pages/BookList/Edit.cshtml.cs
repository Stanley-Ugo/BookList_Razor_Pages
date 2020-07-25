using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList_Razor_Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList_Razor_Pages.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }
        public void OnGet(int id)
        {
            Book = _db.Books.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookInDb = _db.Books.Find(Book.Id);
                bookInDb.ISBN = Book.ISBN;
                bookInDb.Title = Book.Title;
                bookInDb.Author = Book.Author;
                bookInDb.Price = Book.Price;
                bookInDb.Availability = Book.Availability;

                await _db.SaveChangesAsync();
                Message = "Book updated successfuly!";

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}