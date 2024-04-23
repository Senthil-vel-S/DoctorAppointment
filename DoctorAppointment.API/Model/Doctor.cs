namespace DoctorAppointment.API.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DoctorCode { get; set; }
        public string Specialization { get; set; }
        public string Availability { get; set; }
    }
}
