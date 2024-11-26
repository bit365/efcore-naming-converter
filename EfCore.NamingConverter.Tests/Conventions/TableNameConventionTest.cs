using EfCore.NamingConverter.Conventions;
using EfCore.NamingConverter.Converters;
using EfCore.NamingConverter.Tests.TestCases;
using Microsoft.EntityFrameworkCore;

namespace EfCore.NamingConverter.Tests.Conventions
{
    public class TableNameConventionTest
    {
        [Fact]
        public void ProcessEntityTypeAdded_UseSnakeCaseLower_ShouldApplyTableNameConvention()
        {
            // Arrange
            var convention = new TableNameConvention(NameConverter.SnakeCaseLower);
            var entityType = MockBuilder.BuildEntityType(b => b.Entity<SomeEntity>(), convention);
            // Act
            var tableName = entityType.GetTableName();
            // Assert
            Assert.Equal("some_entity", tableName);
        }
    }
}
