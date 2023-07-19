namespace rb.api.ViewModels
{
    public class AddCertificate
    {
        public string Name { get; set; } = null!;
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int UserId { get; set; }
    }
}
