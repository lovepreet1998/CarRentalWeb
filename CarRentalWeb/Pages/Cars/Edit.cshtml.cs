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

namespace CarRentalWeb.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly CarRentalWeb.Data.CarRentalDBContext _context;

        public EditModel(CarRentalWeb.Data.CarRentalDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars
                .Include(c => c.Category)
                .Include(c => c.Company).FirstOrDefaultAsync(m => m.CarID == id);

            if (Car == null)
            {
                return NotFound();
            }
           ViewData["CarCategoryID"] = new SelectList(_context.CarCategories, "CarCategoryID", "CarCategoryName");
           ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName");
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

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.CarID))
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

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarID == id);
        }
    }
}
