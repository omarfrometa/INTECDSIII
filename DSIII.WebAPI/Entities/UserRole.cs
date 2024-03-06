namespace DSIII.WebAPI.Entities
{
    public class UserRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
