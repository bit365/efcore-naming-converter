Ues EfCore.NamingConverter Convert Table Name and Column Name,the base code from System.Text.Json library.

### Install
```shell
dotnet add package EfCore.NamingConverter
```

### Use in DbContext class
```csharp

public class MyDbContext : DbContext
{
	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		configurationBuilder.AddNamingConventions(NamingPolicy.SnakeCaseLower);
	}
}
```

### Support NamingPolicy

- CamelCase (eg: `userName`)
- SnakeCaseLower (eg: `user_name`)
- SnakeCaseUpper (eg: `USER_NAME`)
- KebabCaseLower (eg: `user-name`)
- KebabCaseUpper (eg: `USER-NAME`)
