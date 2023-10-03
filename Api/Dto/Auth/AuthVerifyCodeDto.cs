using System.ComponentModel.DataAnnotations;

namespace VerificationProject.Dto.Auth;
public class AuthVerifyCodeDto{
    [Required]
    public string Code { get; set; } = String.Empty;

    [Required]
    public int Id { get; set; }
}
