using AutoMapper;
using DoctorAppointment.API.Data;
using DoctorAppointment.API.Dto.DoctorDto;
using DoctorAppointment.API.Model;
using DoctorAppointment.API.Repository;
using DoctorAppointment.API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DoctorAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<GetDoctorDto>>> GetDoctors()
        {
            var doctor = await _doctorRepository.GetDoctors();
            if(doctor==null)
            {
                return NoContent();
            }
            var doctors = _mapper.Map<List<GetDoctorDto>>(doctor); 
            return Ok(doctors);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<GetDoctorDto>> GetDoctor(int id)
        {
            var doctor = await _doctorRepository.GetDoctor(id);
            if (doctor == null)
            {
                return NoContent();
            }
            var doctors = _mapper.Map<GetDoctorDto>(doctor);
            return Ok(doctors);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateDoctorDto>> PostDetails([FromBody] CreateDoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.PostDetails(doctor);
            return CreatedAtAction("GetDoctor", new {id=doctor.Id},doctor);
        }
    }
}
