using DoctorAppointment.API.Data;
using DoctorAppointment.API.Model;
using DoctorAppointment.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.API.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public AppointmentRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            Appointment result = await _dbcontext.Appointments.FindAsync(id);
            return result;
        }

        public async Task<List<Appointment>> GetAppointments()
        {
            List<Appointment> result = await _dbcontext.Appointments.ToListAsync();
            return result;
        }

        public async Task PostDetails(Appointment entity)
        {
            await _dbcontext.Appointments.AddAsync(entity);
            await Save();
        }

        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
