using EfCore.NamingConverter.Conventions;
using EfCore.NamingConverter.Converters;
using EfCore.NamingConverter.Tests.TestCases;
using Microsoft.EntityFrameworkCore;

namespace EfCore.NamingConverter.Tests.Conventions
{
    public class ForeignKeyNameConventionTest
    {
        [Fact]
        public void ProcessForeignKeyAdded_UseSnakeCaseLower_ShouldReturnSnakeCaseLower()
        {
            var convention = new ForeignKeyNameConvention(NameConverter.SnakeCaseLower);
            var model = MockBuilder.BuildModel(b => b.Entity<Blog>(), convention);
            var entityType = model.FindEntityType(typeof(Post));

            Assert.NotNull(entityType);

            string? foreignKeyName = entityType.GetForeignKeys().Single().GetConstraintName();

            Assert.NotNull(foreignKeyName);
            Assert.Equal("fk_post_blog_blog_id", foreignKeyName);
        }
    }
}
