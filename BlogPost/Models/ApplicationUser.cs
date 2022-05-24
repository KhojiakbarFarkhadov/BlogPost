using Microsoft.AspNetCore.Identity;

namespace BlogPost.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Post> Posts { get; set; }
    }
}
