﻿namespace TimeasyAPI.src.DTOs.Teacher
{
    public class TeacherDTO
    {
        public string Id { get; set; }
        public string InstituteId { get; set; }
        public string Registration { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AcademicDegree { get; set; }
        public DateOnly BirthDate { get; set; }
        public int TeachingHours { get; set; }
        public DateOnly IfspServiceTime { get; set; }
        public DateOnly CampusServiceTime { get; set; }
    }
}
