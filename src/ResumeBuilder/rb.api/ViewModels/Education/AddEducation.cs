namespace rb.api.ViewModels
{
    public class AddEducation
    {
        public string Place { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int UserId { get; set; }
    }
}
