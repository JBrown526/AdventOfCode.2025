using AdventOfCode2025.Solvers;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace AdventOfCode2025;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddSolvers(this IServiceCollection serviceCollection)
    {
        IEnumerable<Type> solvers = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => typeof(IAoCSolver).IsAssignableFrom(type) && type.IsClass);

        foreach (Type solver in solvers)
        {
            string name = solver.Name;
            Match match = NumberRegex().Match(name);

            if (!match.Success)
            {
                throw new InvalidOperationException(
                    $"Solver {name} does not contain a number in its name to register it");
            }

            int day = int.Parse(match.Groups["number"].Value);
            serviceCollection.AddKeyedSingleton(typeof(IAoCSolver), day, solver);
        }

        return serviceCollection;
    }

    [GeneratedRegex(@"(?<number>\d+)")]
    private static partial Regex NumberRegex();
}
