﻿using TimeasyAPI.src.DTOs.Course.Requests;
using TimeasyAPI.src.DTOs.Courses;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface ICourseServices
    {
        Task<PagedResult<CourseDTO>> GetAllAsync(int page, int pageSize);

        Task RemoveByIdAsync(Guid id);

        Task RemoveCourseSubjectByIdAsync(Guid courseId, Guid subjectId);

        Task<CourseDTO> CreateAsync(CreateCourseRequest request, Guid instituteId);

        Task UpdateAsync(UpdateCourseRequest request);
    }
}
