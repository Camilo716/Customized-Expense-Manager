# CUSTOMIZED EXPENSE MANAGER

A console personal financial management app

-------------------------

## Set Database

1. Clone  <https://github.com/Camilo716/CEM_Database/>
2. Execute reinitializer script (Remember to configurate connection inside the script)

```bash
cd CEM_Database
chmod +x reinitalizeSchema.sh
./reinitalizeSchema.sh 
```

-------------------------

## Run Tests

```
dotnet test
```

## Manage your finances

### 1. Run the API

```bash
cd ./Cem.Api/API
dotnet run
```

### 2. Use console client

``` bash
cd ./Cem.ConsoleClient/ConsoleClient
```

Add a New Expense

``` bash
dotnet run --expense <category> <description> <amount>
```

Add a New Income

``` bash
dotnet run --income <category> <description> <amount>
```

Get a montlhy balance report

``` bash
dotnet run --report
```
<div align="center">
  <img src="https://github.com/Camilo716/Customized-Expense-Manager/assets/105132863/5ba995f3-50cc-4f11-8938-015a2a5e15db" alt="CEM Image">
</div>

