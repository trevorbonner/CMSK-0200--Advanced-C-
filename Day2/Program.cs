// See https://aka.ms/new-console-template for more information
using Day2;

Console.WriteLine("Hello, World!");

var animalList = new List<Animal>();
animalList.Add(new Cat());
animalList.Add(new Mouse());
animalList.Add(new Dog());
animalList.Add(new Bird());
animalList.Add(new SecretSpoiler(AnimalType.None));

foreach(var animal in animalList)
{
    Console.WriteLine($"{animal.AnimalType} makes noise:" + animal.AnimalNoise());
    if(animal.GetType() == typeof(SecretSpoiler))
    {
        var secretSpoiler = (SecretSpoiler)animal;
        Console.WriteLine(secretSpoiler.OnlyThisDoesIt());
    }
}

Console.ReadLine();