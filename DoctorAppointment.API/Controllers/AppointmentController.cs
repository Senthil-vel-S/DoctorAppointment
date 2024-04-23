using AutoMapper;
using DoctorAppointment.API.Data;
using DoctorAppointment.API.Dto.AppointmentDto;
using DoctorAppointment.API.Model;
using DoctorAppointment.API.Repository;
using DoctorAppointment.API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public AppointmentController(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<GetAppointmentDto>> GetAppointments()
        {
            var appointment = await _appointmentRepository.GetAppointments();
            if(appointment==null)
            {
                return NoContent();
            }
            var appointments = _mapper.Map<List<GetAppointmentDto>>(appointment);
            return Ok(appointments);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<GetAppointmentDto>> GetAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAppointment(id);
            if (appointment == null)
            {
                return NoContent();
            }
            var appointments = _mapper.Map<GetAppointmentDto>(appointment);
            return Ok(appointments);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateAppointmentDto>> PostDetails([FromBody] CreateAppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            await _appointmentRepository.PostDetails(appointment);
            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }
    }
}
