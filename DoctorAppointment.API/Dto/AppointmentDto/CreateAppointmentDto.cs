namespace DoctorAppointment.API.Dto.AppointmentDto
{
    public class CreateAppointmentDto
    {
        public string PatientName { get; set; }
        public string Date { get; set; }
        public int DoctorId { get; set; }
    }
}
