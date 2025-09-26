# 🧅 OnionShop (Onion Architecture in .NET 8)

A minimal reference implementation of **Onion Architecture** in C#/.NET.  
The goal is to keep the **Domain Model at the core** and make all dependencies point inward.

## 📂 Project Structure

## 🧅 Onion Layers

1. **Domain (Core)**
   - Entities (`Product`)
   - Value Objects
   - Interfaces (`IProductRepository`)

2. **Application**
   - Use cases (`CreateProductService`)
   - DTOs (commands/results)

3. **Infrastructure**
   - EF Core (`AppDbContext`)
   - Repositories (`ProductRepository`)
   - Dependency Injection wiring

4. **UI / WebApi**
   - Minimal API endpoints
   - Swagger
   - Composition root (configures DI)

   ## 🚀 Quickstart

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- VS Code (with the C# extension)

### Setup
```bash
# create solution
dotnet new sln -n OnionShop
mkdir src

# projects
dotnet new classlib -n OnionShop.Domain -o src/OnionShop.Domain
dotnet new classlib -n OnionShop.Application -o src/OnionShop.Application
dotnet new classlib -n OnionShop.Infrastructure -o src/OnionShop.Infrastructure
dotnet new webapi   -n OnionShop.WebApi -o src/OnionShop.WebApi -minimal

# add to solution
dotnet sln add src/**/**/*.csproj

# references (point inward)
dotnet add src/OnionShop.Application/OnionShop.Application.csproj reference src/OnionShop.Domain/OnionShop.Domain.csproj
dotnet add src/OnionShop.Infrastructure/OnionShop.Infrastructure.csproj reference src/OnionShop.Domain/OnionShop.Domain.csproj
dotnet add src/OnionShop.Infrastructure/OnionShop.Infrastructure.csproj reference src/OnionShop.Application/OnionShop.Application.csproj
dotnet add src/OnionShop.WebApi/OnionShop.WebApi.csproj reference src/OnionShop.Application/OnionShop.Application.csproj
dotnet add src/OnionShop.WebApi/OnionShop.WebApi.csproj reference src/OnionShop.Infrastructure/OnionShop.Infrastructure.csproj