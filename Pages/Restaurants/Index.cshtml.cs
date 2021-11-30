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
        public string NameSort {get; set;}
        [BindProperty(SupportsGet = true)]
        public string AddressSort {get; set;}
        [BindProperty(SupportsGet = true)]
        public string PhoneSort {get; set;}
        [BindProperty(SupportsGet = true)]
        public string CuisineSort {get; set;}
        public SelectList SortList {get; set;}

        public async Task OnGetAsync()
        {
            var query = _context.Restaurant.Select(m => m);

            var query2 = _context.Restaurant.Count();

            MaxPage = query2 / PageSize;

            switch (NameSort)
            {
                case "firstAsc":
                    query = query.OrderBy(m => m.Name);
                    break;
                case "firstDesc":
                    query = query.OrderByDescending(m => m.Name);
                    break;
            }

            switch (AddressSort)
            {
                case "SecondAsc":
                    query = query.OrderBy(m => m.Address);
                    break;
                case "SecondDesc":
                    query = query.OrderByDescending(m => m.Address);
                    break;
            }

            switch (PhoneSort)
            {
                case "ThirdAsc":
                    query = query.OrderBy(m => m.PhoneNumber);
                    break;
                case "ThirdDesc":
                    query = query.OrderByDescending(m => m.PhoneNumber);
                    break;
            }

            switch (CuisineSort)
            {
                case "FourthAsc":
                    query = query.OrderBy(m => m.Cuisine);
                    break;
                case "FourthDesc":
                    query = query.OrderByDescending(m => m.Cuisine);
                    break;
            }

            Restaurant = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}
