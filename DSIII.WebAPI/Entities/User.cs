namespace DSIII.WebAPI.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
