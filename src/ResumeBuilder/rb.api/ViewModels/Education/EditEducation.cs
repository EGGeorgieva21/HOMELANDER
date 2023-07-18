namespace rb.api.ViewModels
{
    public class EditEducation
    {
        public int Id { get; set; }
        public string Place { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
