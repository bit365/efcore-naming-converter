using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace EfCore.NamingConverter.Tests.Conventions
{
    /// <summary>
    ///  The naming convention from EFCore.NamingConventions with some modifications.
    ///  Thanks to the author of the original code.
    /// </summary>
    public class IntegrationTest
    {
        [Fact]
        public void Table_name_is_taken_from_DbSet_property()
        {
            using var context = new BlogContext();
            var entityType = context.Model.FindEntityType(typeof(Blog))!;
            Assert.Equal("blogs", entityType.GetTableName());

            var property = entityType.FindProperty(nameof(Blog.BlogProperty))!;
            Assert.Equal("blog_property", property.GetColumnName());

            var index = Assert.Single(entityType.GetIndexes());
            Assert.Equal("ix_blogs_blog_property", index.GetDatabaseName());
        }

        [Fact]
        public void Table_name_is_taken_from_DbSet_property_with_TPH()
        {
            using var context = new TphBlogContext();

            var blogEntityType = context.Model.FindEntityType(typeof(Blog))!;
            var specialBlogEntityType = context.Model.FindEntityType(typeof(SpecialBlog))!;

            Assert.Equal("blogs", blogEntityType.GetTableName());
            Assert.Equal("blogs", specialBlogEntityType.GetTableName());

            var blogProperty = blogEntityType.FindProperty(nameof(Blog.BlogProperty))!;
            Assert.Equal("blog_property", blogProperty.GetColumnName());
            var specialBlogProperty = specialBlogEntityType.FindProperty(nameof(SpecialBlog.SpecialBlogProperty))!;
            Assert.Equal("special_blog_property", specialBlogProperty.GetColumnName());

            var blogIndex = Assert.Single(blogEntityType.GetIndexes());
            Assert.Equal("ix_blogs_blog_property", blogIndex.GetDatabaseName());
            var specialBlogIndex = Assert.Single(specialBlogEntityType.GetDeclaredIndexes());
            Assert.Equal("ix_blogs_special_blog_property", specialBlogIndex.GetDatabaseName());
        }

        [Fact]
        public void Table_name_is_taken_from_DbSet_property_with_TPT()
        {
            using var context = new TptBlogContext();

            var blogEntityType = context.Model.FindEntityType(typeof(Blog))!;
            var specialBlogEntityType = context.Model.FindEntityType(typeof(SpecialBlog))!;

            Assert.Equal("blogs", blogEntityType.GetTableName());
            Assert.Equal("special_blogs", specialBlogEntityType.GetTableName());

            var blogProperty = blogEntityType.FindProperty(nameof(Blog.BlogProperty))!;
            Assert.Equal("blog_property", blogProperty.GetColumnName());
            var specialBlogProperty = specialBlogEntityType.FindProperty(nameof(SpecialBlog.SpecialBlogProperty))!;
            Assert.Equal("special_blog_property", specialBlogProperty.GetColumnName());

            var blogIndex = Assert.Single(blogEntityType.GetIndexes());
            Assert.Equal("ix_blogs_blog_property", blogIndex.GetDatabaseName());
            var specialBlogIndex = Assert.Single(specialBlogEntityType.GetDeclaredIndexes());
            Assert.Equal("ix_special_blogs_special_blog_property", specialBlogIndex.GetDatabaseName());
        }

        public class Blog
        {
            public int Id { get; set; }
            public required string BlogProperty { get; set; }
        }

        public class SpecialBlog : Blog
        {
            public required string SpecialBlogProperty { get; set; }
        }

        public class BlogContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; } = null!;

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("DataSource=:memory:");
            }

            protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Blog>().HasIndex(b => b.BlogProperty);
            }

            protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
            {
                configurationBuilder.AddNamingConventions(NamingPolicy.SnakeCaseLower);
            }
        }

        public class TphBlogContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; } = null!;
            public DbSet<SpecialBlog> SpecialBlogs { get; set; } = null!;

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("DataSource=:memory:");
            }
            protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
            {
                configurationBuilder.AddNamingConventions(NamingPolicy.SnakeCaseLower);
            }

            protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Blog>().HasIndex(b => b.BlogProperty);
                modelBuilder.Entity<SpecialBlog>().HasIndex(b => b.SpecialBlogProperty);
            }
        }

        public class TptBlogContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; } = null!;
            public DbSet<SpecialBlog> SpecialBlogs { get; set; } = null!;

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("DataSource=:memory:");
            }
            protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
            {
                configurationBuilder.AddNamingConventions(NamingPolicy.SnakeCaseLower);
            }
            protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Blog>().HasIndex(b => b.BlogProperty);
                modelBuilder.Entity<SpecialBlog>().HasIndex(b => b.SpecialBlogProperty);

                modelBuilder.Entity<Blog>().UseTptMappingStrategy();
            }
        }
    }
}
