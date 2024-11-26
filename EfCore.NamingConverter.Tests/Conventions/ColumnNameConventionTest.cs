using EfCore.NamingConverter.Conventions;
using EfCore.NamingConverter.Converters;
using EfCore.NamingConverter.Tests.TestCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfCore.NamingConverter.Tests.Conventions
{
    public class ColumnNameConventionTest
    {
        [Fact]
        public void ProcessPropertyAdded_UseSnakeCaseLower_ShouldApplyColumnNameConvention()
        {
            var convention = new ColumnNameConvention(NameConverter.SnakeCaseLower);
            var entityType = MockBuilder.BuildEntityType(b => b.Entity<SomeEntity>(), convention);
            var property = entityType.GetProperty(nameof(SomeEntity.SomeProperty));

            var identifier = StoreObjectIdentifier.Create(entityType, StoreObjectType.Table).GetValueOrDefault();

            var columnName = property.GetColumnName(identifier);

            Assert.Equal("some_property", columnName);
        }
    }
}