namespace TimeasyAPI.src.Helpers
{
    public static class ErrorMessages
    {

        // Token Services

        public const string InvalidUserError = "Invalid user";

        // Timetable Services
        public const string TimetableNotFound = "No timetable found with the provided Id";
        public const string DeleteTimetableError = "Error while deleting timetable";
        public const string CannotChangeTimetable = "You cannot make changes to this timetable anymore.";
        public const string CreateTimetableError = "An error occurred while creating the timetable";  
        public const string NoAssociatedSubject = "No subject associated with the provided timetable Id";
        public const string NoAssociatedCourse = "No course associated with the provided timetable Id";
        public const string DeleteCourseError = "Error while deleting course from timetable";


        // Course Services
        public const string InvalidSubjectPeriod = "One or more subjects have a period greater than the course period.";
        public const string CreateCourseError = "An error occurred while creating the course.";
        public const string CourseNotFound = "No course found with the provided Id.";
        public const string CourseAlreadyInactive = "Course is already inactive.";
        public const string RemoveCourseError = "An error occurred while removing the course.";
        public const string NoCourseWithSubjects = "No course found with subjects associated.";
        public const string NoSubjectsFound = "No subjects found with the provided Ids.";
        public const string SubjectNotBelongsCourse = "One or more of the provided subjects do not belong to the course.";
        public const string CourseMinSubjects = "A course must have at least one associated subject.";
        public const string UpdateCourseError = "An error occurred while updating the course.";


        // Institute Services
        public const string InstituteNotFound = "No institute found with the provided Id.";
        public const string InvalidIdFormat = "Invalid Id format.";
        public const string UpdateInstituteError = "An error occurred while updating the institute.";

        public const string AddIntervalsError = "An error occurred while adding intervals.";
        public const string IntervalNotFound = "Não foi encontrado nenhum intervalo com o Id informado.";
        public const string DeleteIntervalError = "Um erro ocorreu ao deletar intervalo.";

        // Room services

        public const string RoomNotFound = "No room found with the provided Id.";
        public const string CreateRoomError = "An error occurred while creating the room.";
        public const string RemoveRoomError = "An error occurred during the removal of the room.";
        public const string UpdateRoomError = "An error occurred during the update of the room.";

        public const string ComputerLabMissingOS = "The operational system of the computer lab is mandatory.";
        public const string RoomTypeNotFound = "Room type not found.";
        public const string CreateRoomTypeError = "Error creating room type.";
        public const string DeleteRoomTypeError = "Error deleting room type.";
        public const string UpdateRoomTypeError = "Error updating room type.";
        public const string InvalidOperationalSystem = "OperationalSystem is mandatory for a computer lab.";


        // Subjects Services

        public const string SubjectNotFound = "No subject found with the provided Id.";
        public const string CreateSubjectError = "An error occurred while creating the subject.";
        public const string RemoveSubjectError = "An error occurred during the removal of the subject.";
        public const string UpdateSubjectError = "An error occurred during the update of the subject.";

        public const string DeleteSubjectError = "Error while deleting subject";

        public const string SubjectTypeNotFound = "Subject type not found.";
        public const string CreateSubjectTypeError = "Error creating subject type.";
        public const string DeleteSubjectTypeError = "Error deleting subject type.";
        public const string UpdateSubjectTypeError = "Error updating subject type.";

        // Teacher

        public const string TeacherNotFound = "No teacher found with the provided Id.";
        public const string CreateTeacherError = "An error occurred while creating the teacher.";
        public const string RemoveTeacherError = "An error occurred during the removal of the teacher.";
        public const string UpdateTeacherError = "An error occurred during the update of the teacher.";

        public const string DeleteTeacherError = "Error deleting teacher.";


        // FPA'S
        public const string FpaNotFound = "No FPA found with the provided TimetableId and Teacher info.";

    }
}
