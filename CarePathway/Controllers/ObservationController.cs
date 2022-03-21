using CarePathway.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarePathway.Controllers
{
    [Route("api/Observation")]
    [ApiController]
    public class ObservationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ObservationController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //return Json(new { data = _db.Observation.ToList() });
            string sortVal = Request.Query["sortByCategory"];
            string searchString = Request.Query["searchForMRN"];
            List<Observation> observationsList = await _db.Observation.ToListAsync();
            List<Observation> sortedObservations;
            sortedObservations = observationsList;
            if (sortedObservations != null)
            {
                if (sortVal != null)
                {
                    sortVal = sortVal.ToLower();
                    if (sortVal == "ascending")
                    {
                        sortedObservations = observationsList.OrderBy(o => o.Category).ToList();
                    }
                    if (sortVal == "descending")
                    {
                        sortedObservations = observationsList.OrderByDescending(o => o.Category).ToList();
                    }
                }
            }
            List<Observation> filteredObservations;
            filteredObservations = sortedObservations;
            if (searchString != null)
            {
                filteredObservations = sortedObservations.Where(o => o.Status.ToLower() == searchString.ToLower()).ToList();
            }

            return Json(new { data = filteredObservations });
        }
        [HttpPost]
        public async Task<IActionResult> Create(Observation observation)
        {

            _db.Observation.Add(observation);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = observation.Id }, observation);

        }
        // GET by Id action
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var observation = _db.Observation.FirstOrDefault(o => o.Id == id);
            if (observation == null)
                throw new FileNotFoundException();
            // return NotFound();
            return Json(new {data= observation });
        }
        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Observation observation)
        {
            _db.Observation.Update(observation);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var observationFromDB = _db.Observation.FirstOrDefault(u => u.Id == id);
            if (observationFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _db.Observation.Remove(observationFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
