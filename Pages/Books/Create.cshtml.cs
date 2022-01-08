#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test9.Data;
using Test9.Models;

namespace Test9.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly LibraryHandler _context;

        public CreateModel(LibraryHandler context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Color_Id"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["Author_Id"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //Book.Author = await _context.Authors.SingleAsync(a => a.Id == Book.AuthorId);
            //Book.Color = await _context.Colors.SingleAsync(a => a.Id == Book.ColorId);
            //Book.Category = await _context.Categories.SingleAsync(a => a.Id == Book.AuthorId);
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Books/Index");
        }
    }
}
