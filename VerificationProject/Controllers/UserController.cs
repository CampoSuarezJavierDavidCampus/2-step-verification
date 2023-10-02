
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using VerificationProject.Services;

namespace VerificationProject.Controllers;
public class UserController : BaseApiController{
    private readonly ILogger<UserController> _Logger;
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IApiAuth _Auth;
    public UserController(
        ILogger<UserController> logger,
        IUnitOfWork unitOfWork,
        IApiAuth auth
    ){
        _Logger = logger;
        _UnitOfWork = unitOfWork;
        _Auth = auth;
    }

    [HttpGet("QR/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    public async Task<ActionResult> GetQR(long id){        
        
        try{
            User u = await _UnitOfWork.Users.FindFirst(x => x.Id == id);
            (string UriQR, User UserWithSecret) = _Auth.CreateSecret(u);

            _UnitOfWork.Users.Update(UserWithSecret);

            UriQR = UriQR.Replace("data:image/png;base64", "");

            byte[] img = Convert.FromBase64String(UriQR);
            return File(img,"image/png");
        }
        catch (Exception ex){
            _Logger.LogError(ex.Message);
            return BadRequest("some wrong");
        }  
                               
    }
}
