using CarePathway.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarePathway.Pages.PatientList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Model.Patient> Patients { get; set; }
        public async Task OnGet()
        {
            Patients = await _db.Patient.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var patient = await _db.Patient.FindAsync(id);
            if(patient == null)
            {
                return NotFound();
            }
            _db.Patient.Remove(patient);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
