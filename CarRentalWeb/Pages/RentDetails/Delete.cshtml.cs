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
    public class DeleteModel : PageModel
    {
        private readonly CarRentalWeb.Data.CarRentalDBContext _context;

        public DeleteModel(CarRentalWeb.Data.CarRentalDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RentDetail RentDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RentDetail = await _context.RentDetails
                .Include(r => r.Car).FirstOrDefaultAsync(m => m.RentDetailID == id);

            if (RentDetail == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RentDetail = await _context.RentDetails.FindAsync(id);

            if (RentDetail != null)
            {
                _context.RentDetails.Remove(RentDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
