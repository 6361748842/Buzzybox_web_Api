using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuzzyBox_Web_Api.Data;
using BuzzyBox_Web_Api.Models;
using BuzzyBox_Web_Api.Vm_Model;

namespace BuzzyBox_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usersvm>>> GetUsers()
    {
      var userList = new List<Usersvm>();
      var userlist = _context.Users.ToList();
      foreach (var user in userlist)
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
      return userList;
    }















    // GET: api/Users/5
    [HttpGet("{id}")]
        public async Task<ActionResult<Usersvm>> GetUsers(int id)
        {
             var userList = new List<Usersvm>();
            var user = await _context.Users.FindAsync(id);

              if (user != null)
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
                return Ok(userList);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.UsersId)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.Users.Add(users);
            var userdata = _context.Users.Where(x=>x.Phonenumber == users.Phonenumber && x.Email == users.Email).ToList();
            if(userdata.Count != null && userdata.Count !=0) {

        return BadRequest("Email or phone number already existed");

            }
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetUsers", new { id = users.UsersId }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UsersId == id);
        }
    }
}
