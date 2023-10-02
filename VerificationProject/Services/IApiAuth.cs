using Domain.Entities;

namespace VerificationProject.Services;
public interface IApiAuth{
    (string UriQR, User UserWithSecret) CreateSecret(User u);    
}
