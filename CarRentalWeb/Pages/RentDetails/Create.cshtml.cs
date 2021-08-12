using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalWeb.BusinessLayer;
using CarRentalWeb.Data;

namespace CarRentalWeb.Pages.RentDetails
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
        ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "CarName");
            return Page();
        }

        [BindProperty]
        public RentDetail RentDetail { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RentDetails.Add(RentDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
