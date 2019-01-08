using System;
namespace ArcAPI.EFCore.Entities
{
    public partial class Post
    {
        public Post()
        {
            
        }

        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public Blog Blog { get; set; }
    }
}
