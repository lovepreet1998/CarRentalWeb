using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalWeb.BusinessLayer;
using CarRentalWeb.Data;

namespace CarRentalWeb.Pages.CarCategories
{
    public class DeleteModel : PageModel
    {
        private readonly CarRentalWeb.Data.CarRentalDBContext _context;

        public DeleteModel(CarRentalWeb.Data.CarRentalDBContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarCategory = await _context.CarCategories.FindAsync(id);

            if (CarCategory != null)
            {
                _context.CarCategories.Remove(CarCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
