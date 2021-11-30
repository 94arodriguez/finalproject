using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using finalproject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace finalproject.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly finalproject.Models.RestaurantContext _context;

        public IndexModel(finalproject.Models.RestaurantContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant {get; set;}
        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 20;
        public int TotalRows {get; set;}
        public int MaxPage {get; set;}
        
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}
        public SelectList SortList {get; set;}

        public async Task OnGetAsync()
        {
            var query = _context.Restaurant.Count();
            Restaurant = await _context.Restaurant.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}