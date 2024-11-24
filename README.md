## Introduction

This project provides a naming converter for Entity Framework Core to convert table and column names to specified naming conventions. The source code refers to the naming strategy implementation in the System.Text.Json library. It is currently in preview and may have some issues. We welcome suggestions to help us improve it.

## Installation

```shell
dotnet add package EfCore.NamingConverter
```
## Usage

Using the naming converter in the DbContext class is the default configuration method by Microsoft. You only need to add the naming converter in the ConfigureConventions method. In the next version, we are considering providing DbContextOptions configuration options for easier configuration.
```csharp

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
| PascalCase(Default)     | OrderItem  | OrderItem  |
| CamelCase      | OrderItem  | orderItem  |
| SnakeCaseLower | OrderItem  | order_item |
| SnakeCaseUpper | OrderItem  | ORDER_ITEM |
| KebabCaseLower | OrderItem  | order-item |
| KebabCaseUpper | OrderItem  | ORDER-ITEM |
