using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace CarePathway.Model
{
    [Keyless]
    public class PatientsObservationsTbl
    {
        public string Name { get; set; }
    }
}
