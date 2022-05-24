using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPost.Models
{
    public class Post
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [ForeignKey("Author")]
        public string? AuthorId { get; set; }
        public ApplicationUser? Author { get; set; }
    }
}
