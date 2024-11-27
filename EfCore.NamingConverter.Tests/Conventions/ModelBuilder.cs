using EfCore.NamingConverter.Conventions;
using EfCore.NamingConverter.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Sqlite.Diagnostics.Internal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;


namespace EfCore.NamingConverter.Tests.Conventions
{
    public class ModelBuilder
    {
        public static IModel BuildModel(Action<Microsoft.EntityFrameworkCore.ModelBuilder> builderAction, NamingPolicy namingPolicy = NamingPolicy.SnakeCaseLower)
        {
            var services = MyTestHelpers.Instance.CreateContextServices();

            var conventionSet = services.GetRequiredService<IConventionSetBuilder>().CreateConventionSet();

            conventionSet.Add(new NamingConvention(services, NameConverter.From(namingPolicy)));

            var modelBuilder = new Microsoft.EntityFrameworkCore.ModelBuilder(conventionSet);

            builderAction(modelBuilder);

            var model = modelBuilder.FinalizeModel();

            var contextServices = MyTestHelpers.Instance.CreateContextServices();
            var modelRuntimeInitializer = contextServices.GetRequiredService<IModelRuntimeInitializer>();

            model = modelRuntimeInitializer.Initialize(model, designTime: false, new TestLogger<DbLoggerCategory.Model.Validation, SqliteLoggingDefinitions>());

            return model;
        }

        public static IEntityType BuildEntityType(Action<Microsoft.EntityFrameworkCore.ModelBuilder> builderAction, NamingPolicy namingPolicy = NamingPolicy.SnakeCaseLower) => BuildModel(builderAction, namingPolicy).GetEntityTypes().Single();
    }
}
