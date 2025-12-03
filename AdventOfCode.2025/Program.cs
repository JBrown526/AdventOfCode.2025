using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Solvers;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;

namespace AdventOfCode2025;

public static class Program
{
    public static void Main(string[] args)
    {
        IServiceCollection serviceCollection = new ServiceCollection()
            // Register data providers
            .AddKeyedSingleton<IDataProvider, LineDelimitedDataProvider>(DataProviderKind.LineDelimited)
            .AddKeyedSingleton<IDataProvider, CommaSeparatedLineDataProvider>(DataProviderKind.CommaSeparatedLine)
            // Register solvers
            .AddSolvers();

        ServiceProvider provider = serviceCollection.BuildServiceProvider();

        RootCommand command = RegisterCommand(provider);

        command.Parse(args).Invoke();
    }

    private static RootCommand RegisterCommand(ServiceProvider provider)
    {
        Option<int> dayOption = new("--day", "-d")
        {
            Description = "The day to run",
            Arity = ArgumentArity.ExactlyOne,
            Required = true,
        };
        dayOption.Validators.Add(result =>
        {
            if (result.GetValue(dayOption) is > 12 or < 1)
            {
                result.AddError("Day must be between 1 and 12");
            }
        });
        Option<int> partOption = new("--part", "-p")
        {
            Description = "The part to run",
            Arity = ArgumentArity.ExactlyOne,
            Required = true,
        };
        partOption.Validators.Add(result =>
        {
            if (result.GetValue(partOption) is > 2 or < 1)
            {
                result.AddError("Part can only be 1 or 2");
            }
        });

        RootCommand command = new("Solve for Advent of Code 2025")
        {
            dayOption,
            partOption,
        };
        command.SetAction(parseResult =>
        {
            int day = parseResult.GetRequiredValue(dayOption);
            int part = parseResult.GetRequiredValue(partOption);

            IAoCSolver solver = provider.GetRequiredKeyedService<IAoCSolver>(day);

            string result;
            if (part == 1)
            {
                result = solver.Part1();
            }
            else if (part == 2)
            {
                result = solver.Part2();
            }
            else
            {
                throw new ArgumentException("Part must be 1 or 2", nameof(partOption));
            }

            Console.WriteLine(result);
        });

        return command;
    }
}
