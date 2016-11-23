# Bangazon-Financials
CLI application delivering financial reports to business leadership

## Dependencies
To ensure that the Bangazon Financial Reporting app works as intended make sure that you have the following dependencies and technologies on your local machine

- dotnet 

If you need to download dotnet onto your local machine, visit [Microsoft's Documentation](https://www.microsoft.com/en-us/download/details.aspx?id=30653)

## Installation ALL PLATFORMS

Clone this repo to your local machine. Open `Bangazon-Financials.sll` from the root of the repo directory in Visual Studio.

Determine which directory you would like to store your database file. In `Data/DatabaseGenerator.cs`, update the `connectionString` variable around line 115 with the route to the directory you've selected for your database file, like so:

```
var connectionString = @"Filename=path/to/database.db";
```

In `Data/DatabaseConnection.cs`, update the `dbcon` variable around line 159 with the same directory route you set above, like so:
```
SqliteConnection dbcon = new SqliteConnection(@"Data Source=path/to/database.db");
```

Now you are ready to execute the program in Visual Studio.
