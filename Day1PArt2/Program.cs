using Day1PArt2;

string keepGoing = string.Empty;

var testList = new List<Person>();

while(keepGoing != "stop")
{
    Person person;
    Console.WriteLine("Please enter 0 for Student and 1 for Teacher");
    var type = Console.ReadLine();
    if(type == "0")
    {
        person = new Student();
    }
    else
    {
        person = new Teacher();
    }

    Console.WriteLine("Please enter First Name:");
    var firstName = Console.ReadLine();
    person.FirstName = firstName;

    Console.WriteLine("Please enter Last Name:");
    var lastName = Console.ReadLine();
    person.LastName = lastName;

    Console.WriteLine("Please enter Age:");
    var age = Console.ReadLine();
    if(int.TryParse(age, out int personAge))
    {
        person.Age = personAge;
    }
    else
    {
        person.Age = null;
    }
    testList.Add(person);
    Console.WriteLine("Go Again?");
    keepGoing = Console.ReadLine();
}

foreach(var person in testList)
{
    Console.WriteLine(person);
}