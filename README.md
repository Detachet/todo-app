# TodoApp

A small console to-do list application in C# (.NET 10).

## Features

- Add, list and delete tasks
- Marks tasks as completed
- Tasks are saved to a JSON file and loaded on startup
- Input validation for invalid menu choice and task numbers

## Requirements

- .NET 10 SDK

## Getting started

```bash
git clone https://github.com/Detachet/todo-app.git
cd todo-app
dotnet run
```

## Example

```

=== Feladatlista ===

1. Új feladat
2. Feladat törlése
3. Feladatok listázása
4. Feladat késznek jelölése
5. Kilépés

Válassz egy opciót:

```

## What I learned

- Object-oriented design with a `TodoItem` calss
- Working with `List<T>` and LINQ
- JSON serialization and deserialization with `System.Text.Json`
- Git and GitHub workflow

## Next steps

- Convert to Rest API (ASP.NET Core)
- Store tasks in a database