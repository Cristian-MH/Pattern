# CleanShop (Clean Architecture .NET 8)

A tiny reference implementation of **Clean Architecture** in C#/.NET:

- **Domain** – core entities & business rules (no dependencies)
- **Application** – use cases (depends only on Domain)
- **Infrastructure** – EF Core + external adapters (implements Application ports)
- **WebApi** – minimal API (composition root, depends on Application & Infrastructure)

## Project layout



## Quickstart

### Prereqs
- .NET 8 SDK
- VS Code with the C# extension

### Create solution (optional if cloning)
```bash
dotnet new sln -n CleanShop
mkdir -p src
dotnet new classlib -n CleanShop.Domain -o src/CleanShop.Domain
dotnet new classlib -n CleanShop.Application -o src/CleanShop.Application
dotnet new classlib -n CleanShop.Infrastructure -o src/CleanShop.Infrastructure
dotnet new webapi   -n CleanShop.WebApi -o src/CleanShop.WebApi -minimal
