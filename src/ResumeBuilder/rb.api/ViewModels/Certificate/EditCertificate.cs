namespace rb.api.ViewModels
{
    public class EditCertificate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
