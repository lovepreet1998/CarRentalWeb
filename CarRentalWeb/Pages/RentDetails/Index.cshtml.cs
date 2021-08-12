using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalWeb.BusinessLayer;
using CarRentalWeb.Data;

namespace CarRentalWeb.Pages.RentDetails
{
    public class IndexModel : PageModel
    {
        private readonly CarRentalWeb.Data.CarRentalDBContext _context;

        public IndexModel(CarRentalWeb.Data.CarRentalDBContext context)
        {
            _context = context;
        }

        public IList<RentDetail> RentDetail { get;set; }

        public async Task OnGetAsync()
        {
            RentDetail = await _context.RentDetails
                .Include(r => r.Car).ToListAsync();
        }
    }
}
