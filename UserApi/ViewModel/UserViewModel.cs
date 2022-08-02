namespace UserApi.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<PostViewModel>? Posts { get; set; }
    }
}
