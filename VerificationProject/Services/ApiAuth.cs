using System.Reflection.Metadata;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using TwoFactorAuthNet;
using TwoFactorAuthNet.Providers.Qr;

namespace VerificationProject.Services;
public class AuthService: IAuthService{
    private readonly IPasswordHasher<User> _PasswordHasher;
    private readonly IConfiguration _Conf;
    private readonly int _AccessTokenDuration;
    private readonly int _RefreshTokenTokenDuration;
    private readonly ILogger<AuthService> _Logger;
    public AuthService(
        IPasswordHasher<User> passwordHasher,
        IConfiguration conf ,
        ILogger<AuthService> logger
    ){
        _Conf = conf;
        _PasswordHasher = passwordHasher;
        _Logger = logger;
        //--Token duration
        _ = int.TryParse(conf["JWTSettings:AccessTokenTimeInMinutes"], out _AccessTokenDuration);
        _ = int.TryParse(conf["JWTSettings:RefreshTokenTimeInHours"], out _RefreshTokenTokenDuration);        
    }

    public byte[] CreateQR(ref User u){        
        if( u.Email == null){
            throw new ArgumentNullException(u.Email);
        }        
        var tfa = new TwoFactorAuth(_Conf["JWTSettings:Issuer"],6,30,Algorithm.SHA256, new ImageChartsQrCodeProvider());
        string secret = tfa.CreateSecret(160);
        u.TwoFactorSecret = secret;

        var QR = tfa.GetQrCodeImageAsDataUri(u.Email, u.TwoFactorSecret); 

        string UriQR = QR.Replace("data:image/png;base64,", "");


        return Convert.FromBase64String(UriQR);        
    }

    public bool VerifyCode(string secret, string code){        
        var tfa = new TwoFactorAuth(_Conf["JWTSettings:Issuer"],6,30,Algorithm.SHA256);
        return tfa.VerifyCode(secret, code);
    }

   
}
