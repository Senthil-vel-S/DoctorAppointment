using DoctorAppointment.API.Model;

namespace DoctorAppointment.API.Repository.IRepository
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int id);
        Task PostDetails(Doctor entity);
        Task Save();
    }
}
