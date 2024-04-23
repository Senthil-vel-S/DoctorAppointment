namespace DoctorAppointment.API.Dto.DoctorDto
{
    public class CreateDoctorDto
    {
        public string Name { get; set; }
        public int DoctorCode { get; set; }
        public string Specialization { get; set; }
        public string Availability { get; set; }
    }
}
