﻿namespace DoctorAppointment.API.Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Date { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
