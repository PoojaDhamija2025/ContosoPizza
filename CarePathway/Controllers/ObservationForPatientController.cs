using Microsoft.AspNetCore.Mvc;
using CarePathway.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarePathway.Controllers
{
    [Route("api/ObservationForPatient")]
    [ApiController]
    public class ObservationForPatientController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ObservationForPatientController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Patient> patients = await _db.Patient.ToListAsync();
            List<Observation> observations = await _db.Observation.ToListAsync();
            var data = _db.Patient
        .Join(
            _db.Observation,
            ptMRN => ptMRN.Address,
            obMRN => obMRN.Status,
            (ptMRN, obMRN) => new
            {
                mrn = ptMRN.Address,
                patientName = ptMRN.Name,
                observation = obMRN.Category,
                index = obMRN.Encounter,
                value =obMRN.Values
            }
        ).ToList();

            return Json(new { data });
        }
    }
}
