﻿using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Subject;
using TimeasyAPI.src.DTOs.Subject.Requests;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Models.ValueObjects.Enums;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class SubjectServices : ISubjectService
    {


        private IUnitOfWork _unitOfWork;
        private ISubjectRepository _subjectRepository;
        private Serilog.ILogger _logger;
        public SubjectServices(ISubjectRepository subjectReposository, IUnitOfWork unitOfWork, Serilog.ILogger logger)

        {
            _subjectRepository = subjectReposository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<SubjectDTO> CreateAsync(CreateSubjectRequest request)
        {
            var subject = request.MapToEntitie();

            try
            {
                _unitOfWork.CreateTransaction();
                subject = await _subjectRepository.CreateAsync(subject);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.Error($"Erro ao criar Disciplina ${ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException($"Erro ao criar Disciplina");
            }

            return subject.EntitieToMap();
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            var result = await _subjectRepository.GetByIdAsync(id);

            if (result is null)
            {
                throw new AppException("Disciplina não encontrada.");
            }

            if (!result.Active)
            {
                return;
            }

            result.Active = false;

            try
            {
                _unitOfWork.CreateTransaction();
                _subjectRepository.Update(result);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                _logger.Error($"Erro ao deletar Subject");
                _unitOfWork.Rollback();
                throw new AppException("Erro ao deletar disciplina.");
            }
        }

        public async Task<PagedResult<SubjectDTO>> GetAllAsync(int page, int pageSize)
        {
            var result = await _subjectRepository.GetAllWithRoomTypeAsync(page, pageSize);

            var roomDTOs = result.Results.Select(room =>
            {
                return room.EntitieToMap();
            }).ToList();

            var pagedResultDTO = new PagedResult<SubjectDTO>
            {
                CurrentPage = result.CurrentPage,
                PageSize = result.PageSize,
                RowCount = result.RowCount,
                Results = roomDTOs
            };

            return pagedResultDTO;
        }

        public async Task UpdateAsync(UpdateSubjectRequest request)
        {
            var roomId = request.Id.TryGetIdByString();

            var result = await _subjectRepository.GetByIdAsync(roomId);

            if (result is null)
            {
                throw new AppException("Nenhuma disciplina encontrada com o Id informado.");
            }

            if (request.RoomTypeId != null)
            {
                result.RoomTypeId = Guid.Parse(request.RoomTypeId);
            }

            if (request.Acronym != null)
            {
                result.Acronym = request.Acronym;
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                result.Name = request.Name;
            }

            if (request.Complexity != null)
            {
                result.Complexity = Enum.Parse<SubjectComplexity>(request.Complexity, true);
            }

            try
            {
                _unitOfWork.CreateTransaction();
                _subjectRepository.Update(result);
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