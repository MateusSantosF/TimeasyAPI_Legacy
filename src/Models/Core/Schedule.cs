namespace TimeasyAPI.src.Models.Core
{
    public class Schedule : BaseEntity
    {
        public string Start { get; set; }
        public string End { get; set; }

        // EF Relations

        public FPA FPA { get; set; }

        public Guid FPAId { get; set; }


    }
}
