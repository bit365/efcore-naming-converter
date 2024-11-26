using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Sqlite.Diagnostics.Internal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;


namespace EfCore.NamingConverter.Tests
{
    public class MockBuilder
    {
        public static IModel BuildModel(Action<ModelBuilder> builderAction, IConvention Convention)
        {
            var services = MyTestHelpers.Instance.CreateContextServices();

            var conventionSet = services.GetRequiredService<IConventionSetBuilder>().CreateConventionSet();

            conventionSet.Add(Convention);

            var modelBuilder = new ModelBuilder(conventionSet);

            builderAction(modelBuilder);

            var model = modelBuilder.FinalizeModel();

            var contextServices = MyTestHelpers.Instance.CreateContextServices();
            var modelRuntimeInitializer = contextServices.GetRequiredService<IModelRuntimeInitializer>();

            model = modelRuntimeInitializer.Initialize(model, designTime: false, new TestLogger<DbLoggerCategory.Model.Validation, SqliteLoggingDefinitions>());

            return model;
        }

        public static IEntityType BuildEntityType(Action<ModelBuilder> builderAction, IConvention convention) => BuildModel(builderAction, convention).GetEntityTypes().Single();
    }
}
