using Domain.Entities;
using TwoFactorAuthNet;
using TwoFactorAuthNet.Providers.Qr;

namespace VerificationProject.Services;
public class AuthService: IAuthService{
    private readonly IConfiguration _Conf;
    public AuthService(        
        IConfiguration conf ,
        ILogger<AuthService> logger
    ){
        _Conf = conf;        
    }

    public byte[] CreateQR(ref User u){        
        if( u.Email == null){
            throw new ArgumentNullException(u.Email);
        }

        var tfa = new TwoFactorAuth(
            _Conf["JWTSettings:Issuer"],      //* Issuer
            6,                                //* Longitud del codigo
            30,                               //* Duracion de la generacion
            Algorithm.SHA256,                 //* Algoritmo de cifrado
            new ImageChartsQrCodeProvider()   //* Creador del Qr
        );

        string secret = tfa.CreateSecret(160); //* Crea una patron secreto de 160 bites
        u.TwoFactorSecret = secret;

        var QR = tfa.GetQrCodeImageAsDataUri(
            u.Email,            //* El Label
            u.TwoFactorSecret   //* Patron secreto
        ); //* Genera la uri del QR

        string UriQR = QR.Replace("data:image/png;base64,", "");

        return Convert.FromBase64String(UriQR); //* Regresamos el qr en froma de bytes
    }

    public bool VerifyCode(string secret, string code){   
        //     
        var tfa = new TwoFactorAuth(_Conf["JWTSettings:Issuer"],6,30,Algorithm.SHA256);
        return tfa.VerifyCode( //* valida que el codigo sea generado usando el patron
            secret, //* Patron del Usuario
            code    //* Codigo generado por la aplicaion de autenticacion
        );
    }

   
}
