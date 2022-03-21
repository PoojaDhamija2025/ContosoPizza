namespace CarePathway.Model
{
    public class PatientObservations
    {
        public ObservationsForPatient[] Vitals { get; set; }
        public ObservationsForPatient[] Laboratory { get; set; }

    }
    public class ObservationsForPatient
    {
        public string id { get; set; }
        public observationResults[] observations { get; set; }
        public Patients patient { get; set; }
    }
    public class observationResults
        {
        public string index { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }
    public class Patients
    {
        public string mrn { get; set; }
        public string name { get; set; }

    }

}
