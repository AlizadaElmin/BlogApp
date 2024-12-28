namespace BlogApp.BL.DTOs.UserDtos;

public class UserCreateDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public bool IsMale { get; set; }
}