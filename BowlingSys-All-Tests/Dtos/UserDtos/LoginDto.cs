namespace BowlingSys.Contracts.UserDtos
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class UserExistsDto
    {
        public string Username { get; set; }
        public string Email { get; set; }

    }


    public class UserCreationDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
    }
}
