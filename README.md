[![Build status](https://github.com/ThomasArdal/norC/workflows/build/badge.svg)](https://github.com/ThomasArdal/norC/actions/workflows/build.yml)
[![NuGet](https://img.shields.io/nuget/v/norC.svg)](https://www.nuget.org/packages/norC)

# norC

Get a CRON expression from a human-readable string.

## Installation

```
dotnet add package norC --prerelease
```

## Usage

```csharp
CronExpression cron = Parser.Parse("Every day at 3 PM");
Console.WriteLine(cron); // output: 0 15 * * *

// or

CronExpression cron = "Every month".AsCron();
Console.WriteLine(cron); // output: 0 0 1 * *
```