namespace Hometask4_patterns.Data.Entities
{
    public class Posts:BaseEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        //ONE-TO-MANY RELATIONSHIP
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
