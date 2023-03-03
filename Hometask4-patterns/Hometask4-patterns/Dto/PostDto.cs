using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Hometask4_patterns.Dto
{
    public class PostDto
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title).Length(0, 30);
           // RuleFor(x => x.CreationDate).Equal(p=>DateTime.Now);
        }
    }
}
