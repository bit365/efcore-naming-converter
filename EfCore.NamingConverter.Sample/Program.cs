using EfCore.NamingConverter.Sample;

MyDbContext context = new();

Console.WriteLine("Delete database and create database.");

await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

Console.WriteLine("Database created.");

Console.ReadKey();
