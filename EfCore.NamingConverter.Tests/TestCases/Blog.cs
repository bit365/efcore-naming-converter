namespace EfCore.NamingConverter.Tests.TestCases
{
    public class Blog
    {
        public int BlogId { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }

        public Blog Blog { get; set; }

        public int BlogId { get; set; }

        public string PostTitle { get; set; }
    }
}
