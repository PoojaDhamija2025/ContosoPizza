using Microsoft.AspNetCore.Mvc;
using CarePathway.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;


namespace CarePathway.Controllers
{
    [Route("api/PatientObservation")]
    [ApiController]
    public class PatientsObservationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PatientsObservationController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string name = Request.Query["ptName"];
            string index = Request.Query["obIndex"];
            string oType = Request.Query["obType"];
            
           
            List<PatientsObservationsTbl> _list = await _db.PatientsObservationsTbl.ToListAsync();
            string JsonString = _list[0].Name.ToString();
            var cleanJsonString=JObject.Parse(JsonString);
            var data=Newtonsoft.Json.JsonConvert.DeserializeObject<PatientObservations>(cleanJsonString.ToString());
            var patientList = data.Vitals.Where(r =>( r.patient.name.ToLower() == name.ToLower() )).ToList();
            if(patientList.Count == 0)
            {
                patientList = data.Laboratory.Where(r => (r.patient.name.ToLower() == name.ToLower())).ToList();
            }
            List<observationResults> obResults= new List<observationResults>();
            patientList.ForEach((item) =>
            {
                var items = item.observations.Where(q => q.type.ToLower() == oType.ToLower() && q.index.ToLower() == index.ToLower());
                obResults.AddRange(items);
            });
            var JsonResult = Json(new { obResults });
            
            return JsonResult;
        }
    }
}
