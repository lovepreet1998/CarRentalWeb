using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalWeb.BusinessLayer;
using CarRentalWeb.Data;

namespace CarRentalWeb.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarRentalWeb.Data.CarRentalDBContext _context;

        public IndexModel(CarRentalWeb.Data.CarRentalDBContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Cars
                .Include(c => c.Category)
                .Include(c => c.Company).ToListAsync();
        }
    }
}
