using AutoMapper;
using DoctorAppointment.API.Dto.AppointmentDto;
using DoctorAppointment.API.Dto.DoctorDto;
using DoctorAppointment.API.Model;

namespace DoctorAppointment.API.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, CreateDoctorDto>().ReverseMap();
            CreateMap<Doctor, GetDoctorDto>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
            CreateMap<Appointment, GetAppointmentDto>().ReverseMap();
        }
    }
}
