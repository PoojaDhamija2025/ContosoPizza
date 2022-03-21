using CarePathway.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarePathway.Controllers
{
   [Route("api/Patient")]
   [ApiController]
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PatientController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string sortVal = Request.Query["sortByName"];
            string searchString = Request.Query["searchForPatient"];
            List<Patient> patientsList = await _db.Patient.ToListAsync();
            List<Patient> sortedPatients;
            sortedPatients = patientsList;
            if (sortedPatients != null)
            {
                if (sortVal != null)
                {
                    sortVal = sortVal.ToLower();
                    if (sortVal == "ascending")
                    {
                        sortedPatients = patientsList.OrderBy(o => o.Name).ToList();
                    }
                    if (sortVal == "descending")
                    {
                        sortedPatients = patientsList.OrderByDescending(o => o.Name).ToList();
                    }
                }
            }
            List<Patient> filteredPatients;
            filteredPatients = sortedPatients;
            if (searchString != null)
            {
                filteredPatients = sortedPatients.Where(o => o.Name.ToLower() == searchString.ToLower()).ToList();
            }
        
            return Json(new { data = filteredPatients });
        }
        // POST action
      
      
        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {

            _db.Patient.Add(patient);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = patient.Id }, patient);

        }
        // GET by Id action
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var patient = _db.Patient.FirstOrDefault(p => p.Id == id);

            if (patient == null)
                throw new FileNotFoundException();
            // return NotFound();

            return Json(new { data= patient });
        }
        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Patient patient)
        {
            _db.Patient.Update(patient);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var patientFromDB=_db.Patient.FirstOrDefault(u=>u.Id==id);
            if(patientFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _db.Patient.Remove(patientFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
