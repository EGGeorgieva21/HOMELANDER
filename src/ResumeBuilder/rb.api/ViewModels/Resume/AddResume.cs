namespace rb.api.ViewModels
{
    public class AddResume
    {
        public string Summary { get; set; } = null!;
        public int UserId { get; set; }
        public int TemplateId { get; set; }
    }
}