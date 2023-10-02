using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using TwoFactorAuthNet;
using TwoFactorAuthNet.Providers.Qr;

namespace VerificationProject.Services;
public class ApiAuth: IApiAuth{
    private readonly IPasswordHasher<User> _PasswordHasher;
    private readonly IConfiguration _Conf;
    private readonly int _AccessTokenDuration;
    private readonly int _RefreshTokenTokenDuration;
    public ApiAuth(
        IPasswordHasher<User> passwordHasher,
        IConfiguration conf 
    ){
        _Conf = conf;
        _PasswordHasher = passwordHasher;

        //--Token duration
        _ = int.TryParse(conf["JWTSettings:AccessTokenTimeInMinutes"], out _AccessTokenDuration);
        _ = int.TryParse(conf["JWTSettings:RefreshTokenTimeInHours"], out _RefreshTokenTokenDuration);        
    }

    public (string UriQR, User UserWithSecret) CreateSecret(User u){
        var tfa = new TwoFactorAuth(_Conf["JWTSettings:Issuer"],8,30,Algorithm.SHA256, new ImageChartsQrCodeProvider());
        string secret =  tfa.CreateSecret(160);
        string UriQR = tfa.GetQrCodeImageAsDataUri(u.Email, secret);
        u.TwoFactorSecret = secret;

        return (UriQR, u);
    }

   
}
