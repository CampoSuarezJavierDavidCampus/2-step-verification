namespace Domain.Entities;
public class User{
    public long Id { get; set; }    
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? TwoFactorSecret { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
