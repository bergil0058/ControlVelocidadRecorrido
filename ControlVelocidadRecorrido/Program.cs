// See https://aka.ms/new-console-template for more information
using Abstractions;
using Implementations.Solvers;
using Implementations.DataProviders;
using System.Configuration;

//Console.WriteLine("Hello, World!");

try
{

    ISolver iSolver = new GenericSolver();
    IDataProvider iProvider = new XMLDataProvider(ConfigurationManager.AppSettings["InputFileName"]);
    ControlVelocidadRecorrido.ControlVelocidadRecorrido iApp = new(iSolver, iProvider);

    Console.WriteLine("Resolving exercise. . .");
    await iApp.Run();
    Console.WriteLine("Exercise solved succesfully!");
    

}
catch (Exception ex)
{
    Console.WriteLine("Fatal error:");
    Console.WriteLine(ex.ToString());
}
finally
{
    Console.WriteLine();
    Console.WriteLine("Press any key to exit");
    Console.ReadLine();
}