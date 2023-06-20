// See https://aka.ms/new-console-template for more information

using Day5;

List<bool> boolList = new List<bool>();
List<int> intList = new List<int>();
GenericSerializer<string> seriializer = new GenericSerializer<string>();
GenericSerializer<Entity> entitySeriializer = new GenericSerializer<Entity>();
Console.WriteLine(seriializer.Serialize("Test"));
Console.WriteLine(entitySeriializer.Serialize(new Entity()));

var consoleService = new ConsoleService();

BaseConsoleService baseConsoleService = consoleService;
IConsoleService consoleServiceInterface = consoleService;
ISecondInterface secondInterface = consoleService;

secondInterface.Name = "Test";
consoleServiceInterface.ForegroundColor = ConsoleColor.Green;
//baseConsoleService.DoAbstractStuff();

var interFaceList = new List<IConsoleService>();
interFaceList.Add(consoleService);
interFaceList.Add(new SecondClass());

foreach(var service in interFaceList)
{
    Console.WriteLine(service.ReturnValue());
}

Console.WriteLine("Hello, World!");
