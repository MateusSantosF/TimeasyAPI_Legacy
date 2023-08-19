using System.Globalization;
using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Teacher;
using TimeasyAPI.src.DTOs.Teacher.Requests;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Models.ValueObjects.Enums;
using TimeasyAPI.src.Repositories;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class TeacherServices : ITeacherServices
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeacherRepository _teacherRepository;
        private readonly Serilog.ILogger _logger;
        public TeacherServices(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork, Serilog.ILogger logger)
        {
            _teacherRepository = teacherRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<TeacherDTO> CreateAsync(CreateTeacherRequest request, string instituteId)
        {

            var subject = request.MapToEntitie();

            try
            {
                _unitOfWork.CreateTransaction();
                subject.InstituteId = Guid.Parse(instituteId);
                subject = await _teacherRepository.CreateAsync(subject);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception )
            {
                _logger.Error($"Erro ao criar Professor");
                _unitOfWork.Rollback();
                throw new DatabaseException($"Erro ao criar Professor");
            }

            return subject.EntitieToMap();
        }

        public async Task<PagedResult<TeacherDTO>> GetAllAsync(int page, int pageSize)
        {
            var result =  await _teacherRepository.GetAllAsync(page, pageSize);

            var teacherDTOs = result.Results.Select(room =>
            {
                return room.EntitieToMap();
            }).ToList();

            var pagedResultDTO = new PagedResult<TeacherDTO>
            {
                CurrentPage = result.CurrentPage,
                PageSize = result.PageSize,
                RowCount = result.RowCount,
                Results = teacherDTOs
            };

            return pagedResultDTO;
        }

        public async Task RemoveByIdAsync(Guid id)
        {

            var result = await _teacherRepository.GetByIdAsync(id);

            if (result is null)
            {
                throw new AppException("Professor não encontrado.");
            }

            if (!result.Active)
            {
                return;
            }

            result.Active = false;

            try
            {
                _unitOfWork.CreateTransaction();
                _teacherRepository.Update(result);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                _logger.Error($"Erro ao deletar Teacher");
                _unitOfWork.Rollback();
                throw new AppException("Erro ao deletar Professor.");
            }
        }

        public async Task UpdateAsync(UpdateTeacherRequest request)
        {

            var teacherId = request.TeacherId.TryGetIdByString();

            var teacher = await _teacherRepository.GetByIdAsync(teacherId);

            if(teacher == null)
            {
                throw new AppException("Nenhum professor encontrado com o Id informado.");
            }

            if (request.FullName != null)
            {
                teacher.FullName = request.FullName;
            }

            if (request.Email != null)
            {
                teacher.Email = request.Email;
            }

            if (request.Registration != null)
            {
                teacher.Registration = request.Registration;
            }

            if (request.AcademicDegree != null)
            {
                teacher.AcademicDegree = Enum.Parse<AcademicDegree>(request.AcademicDegree, true);
            }

            if (request.BirthDate != null)
            {
                teacher.BirthDate = (DateOnly) request.BirthDate;
            }

            if (request.TeachingHours != null)
            {
                teacher.TeachingHours = (int)request.TeachingHours;
            }

            if (request.IfspServiceTime != null)
            {
                teacher.IfspServiceTime = (DateOnly)request.IfspServiceTime;
            }

            if (request.CampusServiceTime != null)
            {
                teacher.CampusServiceTime = (DateOnly)request.CampusServiceTime;
            }

            try
            {
                _unitOfWork.CreateTransaction();
                _teacherRepository.Update(teacher);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new DatabaseException("Um erro ocorreu durante a atualização.");
            }
        }
    }
}
