namespace TimeasyAPI.src.Models.Core
{
    public class Schedule : BaseEntity
    {
        public string Start { get; set; }
        public string End { get; set; }

        // EF Relations
        public Guid FPAId { get; set; }
        public FPA FPA { get; set; }

    }
}
