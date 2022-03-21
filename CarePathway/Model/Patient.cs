using System.ComponentModel.DataAnnotations;

namespace CarePathway.Model
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string AdharCardNumber { get; set; }
        public string Address { get; set; }
        public string AttendentName { get; set; }
        public string AttendentRelationship { get; set; }
        public string AttendentPhoneNumber { get; set; }
       

    }
}
