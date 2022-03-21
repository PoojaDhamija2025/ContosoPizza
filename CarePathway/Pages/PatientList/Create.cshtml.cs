using CarePathway.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace CarePathway.Pages.PatientList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Patient Patient { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) {
              await _db.Patient.AddAsync(Patient);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else { return Page(); }
        }
    }
}
