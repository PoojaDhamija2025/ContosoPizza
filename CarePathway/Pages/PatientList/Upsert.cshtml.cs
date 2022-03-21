using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarePathway.Model;
using Microsoft.EntityFrameworkCore;

namespace CarePathway.Pages.PatientList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;
        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Patient Patient { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Patient=new Patient();
            if(id==null)
            {
                //create
                return Page();
            }
            //update
            Patient = await _db.Patient.FirstOrDefaultAsync(u => u.Id == id);
            if(Patient==null)
            { return NotFound(); }
            return Page();
            
        }
       
        public async Task<IActionResult> OnPost(Patient patient)
        {
            if (ModelState.IsValid)
            {
                if(Patient.Id==0)
                {
                    _db.Patient.Add(patient);
                }
                else
                {
                    _db.Patient.Update(patient);
                }

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            else { return Page(); }
        }
    }
}