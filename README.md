[![Nuget](https://img.shields.io/nuget/v/EFCore.NamingConverter)](https://www.nuget.org/packages/EFCore.NamingConverter/)

 ## Introduction

This project provides a naming converter for Entity Framework Core to accommodate various database naming conventions. The naming strategy is inspired by the source code of System.Text.Json, while the implementation of the conventioner is derived from the source code of EFCore.NamingConventions. The project is compatible with and supports .NET 8.0 and .NET 9.0 versions.

## Installation

```shell
dotnet add package EfCore.NamingConverter
```
## Usage

The recommended approach is to utilize a naming converter within the DbContext class by overriding the ConfigureConventions method to add it.
```csharp
using EfCore.NamingConverter;

public class MyDbContext : DbContext
{
   protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
   {
   	configurationBuilder.AddNamingConventions(NamingPolicy.SnakeCaseLower);
   }
}
```

## Policies

| Naming Policy  | Original | Converted |
|----------------|--------------|--------------|
| PascalCase(Default)     | FullName  | FullName  |
| CamelCase      | FullName  | fullName  |
| SnakeCaseLower | FullName  | full_name |
| SnakeCaseUpper | FullName  | FULL_NAME |
| KebabCaseLower | FullName  | full-name |
| KebabCaseUpper | FullName  | FULL-NAME |