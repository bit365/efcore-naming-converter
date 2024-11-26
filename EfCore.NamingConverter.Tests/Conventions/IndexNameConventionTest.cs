using EfCore.NamingConverter.Conventions;
using EfCore.NamingConverter.Converters;
using EfCore.NamingConverter.Tests.TestCases;
using Microsoft.EntityFrameworkCore;

namespace EfCore.NamingConverter.Tests.Conventions
{
    public class IndexNameConventionTest
    {
        [Fact]
        public void ProcessIndexAdded_UseSnakeCaseLower_ShouldReturnSnakeCaseLower()
        {
            var convention = new IndexNameConvention(NameConverter.SnakeCaseLower);

            var entityType = MockBuilder.BuildEntityType(b => b.Entity<SomeEntity>().HasIndex(x => x.SomeProperty), convention);

            string? indexName = entityType.GetIndexes().Single()?.GetDatabaseName();

            Assert.NotNull(indexName);
            Assert.Equal("ix_some_entity_some_property", indexName);
        }
    }
}
