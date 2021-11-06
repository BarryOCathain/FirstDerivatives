namespace FD.EnergySupplierPal.Console
{
    using System;
    using System.Linq;
    using Handlers;
    using Microsoft.Extensions.Configuration;

    public class Program
    {
        private const string ExitText = "exit";
        private static IInputManager _inputManager;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true);

            var config = builder.Build();

            _inputManager = CreateInputManager(config);

            Console.WriteLine("Please enter your commands:");

            var line = Console.ReadLine();

            while (!line.Equals(ExitText, StringComparison.InvariantCultureIgnoreCase))
            {
                var inputArgs = line.Split(' ');

                if (inputArgs.Length < 2)
                    Console.WriteLine($"The command {line}, does not have valid arguments");
                else
                {

                    var inputType = inputArgs[0].ToLower();

                    try
                    {
                        switch (inputType)
                        {
                            case "input":
                                _inputManager.InitializePlans(inputArgs[1]);
                                break;
                            case "annual_cost":
                                if (!int.TryParse(inputArgs[1], out var consumption))
                                    Console.WriteLine("Annual Cost is not a valid number");
                                else
                                {
                                    var costs = _inputManager.CalculateCosts(consumption);
                                    costs = costs.OrderBy(c => c.Cost);

                                    foreach (var planCost in costs)
                                        Console.WriteLine(planCost.ToString());
                                }
                                break;
                            default:
                                Console.WriteLine($"The input: {line}, is not a valid command");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                line = Console.ReadLine();
            }
        }

        static InputManager CreateInputManager(IConfigurationRoot config)
        {
            return new InputManager(new PlanHandler(), new CostHandler());
        }
    }
}
