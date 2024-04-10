using System.ComponentModel.DataAnnotations;

namespace Core.UserEnitiy
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Password { get; set; }
    }
}
