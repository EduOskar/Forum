namespace InaForum.Server.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Username { get; set; } = default!;

        public string Email { get; set; } = default!;
    }
}
