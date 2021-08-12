using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalWeb.BusinessLayer;
using CarRentalWeb.Data;

namespace CarRentalWeb.Pages.RentDetails
{
    public class EditModel : PageModel
    {
        private readonly CarRentalWeb.Data.CarRentalDBContext _context;

        public EditModel(CarRentalWeb.Data.CarRentalDBContext context)
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
           ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "CarName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentDetailExists(RentDetail.RentDetailID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RentDetailExists(int id)
        {
            return _context.RentDetails.Any(e => e.RentDetailID == id);
        }
    }
}
