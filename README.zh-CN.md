## 介绍

该项目为 Entity Framework Core 提供了一个命名转换器，用于将表名和列名转换为指定的命名规则，源码参阅 System.Text.Json 库中命名策略实现，目前是预览版，可能会有一些问题，欢迎大家提出建议，让我们改进它。

## 安装
```shell
dotnet add package EfCore.NamingConverter
```
## 使用

在 DbContext 类中使用命名转换器是微软默认的配置方式，只需要在 ConfigureConventions 方法中添加命名转换器即可，下一个版本考虑提供 DbContextOptions 配置项，方便配置。

```csharp

public class MyDbContext : DbContext
{
   protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
   {
   	configurationBuilder.AddNamingConventions(NamingPolicy.SnakeCaseLower);
   }
}
```

## 规则

| Naming Policy  | Original | Converted |
|----------------|--------------|--------------|
| PascalCase(Default)     | OrderItem  | OrderItem  |
| CamelCase      | OrderItem  | orderItem  |
| SnakeCaseLower | OrderItem  | order_item |
| SnakeCaseUpper | OrderItem  | ORDER_ITEM |
| KebabCaseLower | OrderItem  | order-item |
| KebabCaseUpper | OrderItem  | ORDER-ITEM |
