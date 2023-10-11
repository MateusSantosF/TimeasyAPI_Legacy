namespace TimeasyCore.src.Core
{
    public class Schedule
    {
        public Dictionary<DayOfWeek, List<Class>> ClassesByDay { get; }

        public Schedule()
        {
            ClassesByDay = new Dictionary<DayOfWeek, List<Class>>();
            InitializeDaysOfWeek();
        }
        private void InitializeDaysOfWeek()
        {
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                ClassesByDay[day] = new List<Class>();
            }
        }

        public void AddClass(DayOfWeek day, Class classItem)
        {
            if (ClassesByDay.ContainsKey(day))
            {
                ClassesByDay[day].Add(classItem);
            }
        }
    }

}