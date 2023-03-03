using System.ComponentModel.DataAnnotations;

namespace Hometask4_patterns.Data.Entities
{
    public class Blog:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int PostsCount { get; set; }

        //ONE-TO-MANY RELATIONSHIP
        public ICollection<Posts> Posts { get; set; }
    }
}
