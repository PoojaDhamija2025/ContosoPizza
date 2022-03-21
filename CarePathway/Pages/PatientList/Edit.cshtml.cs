using CarePathway.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarePathway.Pages.PatientList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        { 
            _db = db;
        }
        [BindProperty]
        public Patient Patient { get; set; }
        public async Task OnGet(int id)
        {
            Patient=await _db.Patient.FindAsync(id);
        }
        public async Task<IActionResult> OnPost(Patient patient)
        {
            if (ModelState.IsValid)
            {
                var patientFromDB=await _db.Patient.FindAsync(Patient.Id);
                patientFromDB.Name= Patient.Name;
                patientFromDB.DOB= Patient.DOB;
                patientFromDB.Address= Patient.Address;
                patientFromDB.AdharCardNumber= Patient.AdharCardNumber;
                patientFromDB.PhoneNumber= Patient.PhoneNumber;
                patientFromDB.AttendentPhoneNumber= Patient.AttendentPhoneNumber;
                patientFromDB.AttendentRelationship= Patient.AttendentRelationship;
                patientFromDB.AttendentName= Patient.AttendentName;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            else { return Page(); }
        }
    }
}
