
using System.ComponentModel.DataAnnotations;

namespace CarePathway.Model
{
    public class Observation
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Subject { get; set; }
        public string Encounter { get; set; }
        public string Effective { get; set; }
        public string Performer { get; set; }
        public string Values { get; set; }
        public string Note { get; set; }
        public string BodySite { get; set; }
        public string Method { get; set; }
        public string Speciman { get; set; }
        public string Device { get; set; }


    }
}
