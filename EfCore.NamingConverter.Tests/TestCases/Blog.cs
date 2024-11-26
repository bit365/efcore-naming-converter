namespace EfCore.NamingConverter.Tests.TestCases
{
    public class Blog
    {
        public int BlogId { get; set; }

        public required List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }

        public required Blog Blog { get; set; }

        public int BlogId { get; set; }

        public required string PostTitle { get; set; }
    }
}
