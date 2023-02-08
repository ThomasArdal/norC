# norC

Get a CRON expression from a human-readable string.

## Usage

```csharp
CronExpression cron = Parser.Parse("Every day at 3 PM");
Console.WriteLine(cron); // output: 0 15 * * *
```