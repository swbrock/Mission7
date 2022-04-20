using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission7.Models;
using Mission7.Infrastucture;

namespace Mission7.Pages
{
    public class BuyBooksModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public BuyBooksModel(IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public int total { get; set; }
        public virtual int TotalBooks()
        {
            foreach(var i in basket.Items)
            {
                total = total + 1;
            }
            return total;
        }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);
            total++;
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            total--;
            return RedirectToPage(new { ReturnUrl = returnUrl });
            
        }
    }
}
