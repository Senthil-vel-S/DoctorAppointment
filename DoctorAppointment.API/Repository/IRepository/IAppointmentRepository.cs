using DoctorAppointment.API.Model;

namespace DoctorAppointment.API.Repository.IRepository
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointments();
        Task<Appointment> GetAppointment(int id);
        Task PostDetails(Appointment entity);
        Task Save();
    }
}
