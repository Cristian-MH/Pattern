# Pattern

Reference repo with two .NET API samples that demonstrate layered architecture styles:

- `Onion/`: Onion Architecture sample (`OnionShop`)
- `CleanCode/`: Clean Architecture sample (`CleanShop`)

Both projects currently target `.NET 9` and use `EF Core InMemory` for quick local runs.

## Prerequisites

- .NET 9 SDK

## Repository Layout

```text
Pattern/
├── Onion/
│   ├── OnionShop.sln
│   └── src/
│       ├── OnionShop.Domain
│       ├── OnionShop.Application
│       ├── OnionShop.Infrastructure
│       └── OnionShop.WebApi
└── CleanCode/
    ├── CleanShop.sln
    └── src/
        ├── CleanShop.Domain
        ├── CleanShop.Application
        ├── CleanShop.Infrastructure
        └── CleanShop.WebApi
```

## Run OnionShop

```bash
cd Onion/src/OnionShop.WebApi
dotnet run
```

Default local URLs:

- `http://localhost:5114`
- `https://localhost:7202`

Swagger UI:

- `http://localhost:5114/swagger`

Create product example:

```bash
curl -X POST "http://localhost:5114/products" \
  -H "Content-Type: application/json" \
  -d '{
    "sku": "SKU-001",
    "name": "Coffee Mug",
    "price": 12.5
  }'
```

## Run CleanShop

```bash
cd CleanCode/src/CleanShop.WebApi
dotnet run
```

Default local URLs:

- `http://localhost:5013`
- `https://localhost:7181`

Swagger UI:

- `http://localhost:5013/swagger`

Create order example:

```bash
curl -X POST "http://localhost:5013/orders" \
  -H "Content-Type: application/json" \
  -d '{
    "customerEmail": "alex@example.com",
    "items": [
      { "sku": "SKU-001", "quantity": 2, "unitPrice": 12.5 }
    ]
  }'
```

Get order by id:

```bash
curl "http://localhost:5013/orders/<order-id>"
```
