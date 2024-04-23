using DoctorAppointment.API.Data;
using DoctorAppointment.API.Model;
using DoctorAppointment.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.API.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public DoctorRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Doctor> GetDoctor(int id)
        {
            Doctor result = await _dbcontext.Doctors.FindAsync(id);
            return result;
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            List<Doctor> result = await _dbcontext.Doctors.ToListAsync();
            return result;
        }

        public async Task PostDetails(Doctor entity)
        {
            await _dbcontext.Doctors.AddAsync(entity);
            await Save();
        }

        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
