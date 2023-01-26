using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuzzyBox_Web_Api.Data;
using BuzzyBox_Web_Api.Models;
using BuzzyBox_Web_Api.Vm_Model;
using ceTe.DynamicPDF;

namespace BuzzyBox_Web_Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class loginController : ControllerBase
  {
    private readonly DataContext _context;

    public loginController(DataContext context)
    {
      _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> Login(Users loginModel)
    {
      if (loginModel == null)
      {
        return BadRequest("Invalid client request");
      }

      var login = _context.Users
          .Where(u => (u.Phonenumber == loginModel.Phonenumber || u.Email == loginModel.Phonenumber) &&
                                  (u.Password == loginModel.Password)).ToList();
      if (login == null )
      {
        return Content("return Bad request");
      }

      var userList = new List<Usersvm>();
      var userlist = _context.Users.ToList();
      foreach (var user in login)
      {
        var isuser = new Usersvm();
        isuser.UsersId = user.UsersId;
        isuser.Username = user.Username;
        isuser.Phonenumber = user.Phonenumber;
        isuser.Email = user.Email;
        isuser.Password = user.Password;
        isuser.RoleId = user.RoleId;
        if (user.RoleId != 0 && user.RoleId != null)
        {
          isuser.RoleName = _context.Roles.Find(user.RoleId).RoleName;
        }
          userList.Add(isuser);



      }
      return Ok(new {userList} );
    }
  }


}

