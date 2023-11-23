# CUSTOMIZED EXPENSE MANAGER (CEM)

A console personal financial management app

-------------------------
## Run Tests
```
dotnet test
```

## Set Database
```bash
cd ./Cem.Api/API
dotnet ef migrations add 'Name'
dotnet ef database update
```
Or use https://github.com/Camilo716/CEM_Database/ (WIP)

-------------------------
## Manage your finances
### 1. Run the API
```bash
cd ./Cem.Api/API
dotnet run
```

### 2. Use console client
```
cd ./Cem.ConsoleClient/ConsoleClient
```
Add a New Expense
```
dotnet run --expense <category> <description> <amount>
```

Add a New Income
```
dotnet run --income <category> <description> <amount>
```

Get a montlhy report
```
dotnet run --report
```

