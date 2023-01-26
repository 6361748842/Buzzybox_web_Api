namespace BuzzyBox_Web_Api.Models
{
  public class Users
  {
    public int UsersId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phonenumber { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
  }
}
