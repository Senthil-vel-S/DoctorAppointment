namespace DoctorAppointment.API.Dto.DoctorDto
{
    public class GetDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DoctorCode { get; set; }
        public string Specialization { get; set; }
        public string Availability { get; set; }
    }
}
