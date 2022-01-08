#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test9.Data;
using Test9.Models;

namespace Test9.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Test9.Data.LibraryHandler _context;

        public IndexModel(Test9.Data.LibraryHandler context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Color).ToListAsync();
        }
        public IActionResult OnPostSearch()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Book = _context.Books.
                 Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Color).Where(b => b.Name.ToLower().Contains(SearchTerm.ToLower())).ToList();
                return Page();
            }
            return RedirectToPage("/Books/Index");
        }
        public IActionResult OnPostByCategory()
        {
            Book = _context.Books.
                 Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Color).OrderBy(b => b.Category.Name).ToList();
            return Page();

        }
        public IActionResult OnPostByAuthor()
        {
            Book = _context.Books.
                 Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Color).
                OrderBy(b => b.Author.Name).ToList();
            return Page();
        }
        public IActionResult OnPostByColor()
        {
            {
                Book = _context.Books.
                 Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Color).OrderByDescending(b => b.Color.Name).ToList();
            }
            return Page();
        }
        public IActionResult OnPostByName()
        {
            Book = _context.Books.
                 Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Color).OrderBy(b => b.Name).ToList();
            return Page();
        }
    }
}
