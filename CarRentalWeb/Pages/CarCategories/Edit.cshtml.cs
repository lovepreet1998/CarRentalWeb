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

namespace CarRentalWeb.Pages.CarCategories
{
    public class EditModel : PageModel
    {
        private readonly CarRentalWeb.Data.CarRentalDBContext _context;

        public EditModel(CarRentalWeb.Data.CarRentalDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarCategory CarCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarCategory = await _context.CarCategories.FirstOrDefaultAsync(m => m.CarCategoryID == id);

            if (CarCategory == null)
            {
                return NotFound();
            }
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

            _context.Attach(CarCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarCategoryExists(CarCategory.CarCategoryID))
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

        private bool CarCategoryExists(int id)
        {
            return _context.CarCategories.Any(e => e.CarCategoryID == id);
        }
    }
}
