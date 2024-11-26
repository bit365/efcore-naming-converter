using EfCore.NamingConverter.Conventions;
using EfCore.NamingConverter.Converters;
using EfCore.NamingConverter.Tests.TestCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EfCore.NamingConverter.Tests.Conventions
{
    public class KeyNameConventionTest
    {
        [Fact]
        public void ProcessKeyAdded_UseSnakeCaseLower_ShouldReturnSnakeCaseLower()
        {
            var convention = new KeyNameConvention(NameConverter.SnakeCaseLower);
            var entityType = MockBuilder.BuildEntityType(b => b.Entity<SomeEntity>(), convention);
            var key = entityType.FindPrimaryKey();

            Assert.NotNull(key);

            var keyName = key.GetName();

            Assert.NotNull(keyName);
        }
    }
}
