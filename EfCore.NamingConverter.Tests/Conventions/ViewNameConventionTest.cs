using EfCore.NamingConverter.Conventions;
using EfCore.NamingConverter.Converters;
using EfCore.NamingConverter.Tests.TestCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfCore.NamingConverter.Tests.Conventions
{
    public class ViewNameConventionTest
    {

        [Fact]
        public void ProcessEntityTypeAdded_UseSnakeCaseLower_ShouldApplyViewNameConvention()
        {
            // Arrange
            var convention = new ViewNameConvention(NameConverter.SnakeCaseLower);

            var entityType = MockBuilder.BuildEntityType(b => b.Entity<SomeEntity>(e =>
            {
                e.ToView("some_entity_view");
            }), convention);

            // Act
            var viewName = entityType.GetViewName();

            // Assert
            Assert.Equal("some_entity_view", viewName);
        }

        [Fact]
        public void ProcessColumnTypeAdded_UseSnakeCaseLower_ShouldApplyViewNameColumnConvention()
        {
            var convention = new ColumnNameConvention(NameConverter.SnakeCaseLower);
            var entityType = MockBuilder.BuildEntityType(b => b.Entity<SomeEntity>(e =>
            {
                e.ToView("SomeEntityView");
            }), convention);

            var property = entityType.GetProperty(nameof(SomeEntity.SomeProperty));

            var identifier = StoreObjectIdentifier.Create(entityType, StoreObjectType.View).GetValueOrDefault();

            var columnName = property.GetColumnName(identifier);

            Assert.Equal("some_property", columnName);
        }
    }
}
