using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Hometask4_patterns.Dto
{
    public class BlogDto
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Description  { get; set; }
        public string Name { get; set; }
        public int PostsCount { get; set; }
    }
        public class BlogValidator : AbstractValidator<BlogDto>
        { 
            public BlogValidator()
            {
                RuleFor(x => x.Name).Length(0, 10);
                RuleFor(x => x.PostsCount).GreaterThan(5);
            }
        }
}
