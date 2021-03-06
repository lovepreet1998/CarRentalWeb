using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalWeb.BusinessLayer;
using CarRentalWeb.Data;

namespace CarRentalWeb.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CarRentalWeb.Data.CarRentalDBContext _context;

        public CreateModel(CarRentalWeb.Data.CarRentalDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarCategoryID"] = new SelectList(_context.CarCategories, "CarCategoryID", "CarCategoryName");
        ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
