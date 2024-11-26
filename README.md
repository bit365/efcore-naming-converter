[![Nuget](https://img.shields.io/nuget/v/EFCore.NamingConverter)](https://www.nuget.org/packages/EFCore.NamingConverter/)

 ## Introduction

This project provides a naming converter for Entity Framework Core to convert table and column names to specified naming conventions. The source code refers to the naming strategy implementation in the System.Text.Json library.  We welcome suggestions to help us improve it.

## Installation

```shell
dotnet add package EfCore.NamingConverter
```
## Usage

Using the naming converter in the DbContext class is the default configuration method by Microsoft. You only need to add the naming converter in the ConfigureConventions method. In the next version, we are considering providing DbContextOptions configuration options for easier configuration.
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

## Rules

| Naming Policy  | Original | Converted |
|----------------|--------------|--------------|
| PascalCase(Default)     | FullName  | FullName  |
| CamelCase      | FullName  | fullName  |
| SnakeCaseLower | FullName  | full_name |
| SnakeCaseUpper | FullName  | FULL_NAME |
| KebabCaseLower | FullName  | full-name |
| KebabCaseUpper | FullName  | FULL-NAME |

## Github

https://github.com/bit365/efcore-naming-converter

If you are interested in this project, feel free to star and fork it. You are also welcome to submit issues and pull requests to help us improve the project.
