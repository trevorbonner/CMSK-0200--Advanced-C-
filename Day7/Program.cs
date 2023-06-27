using Day7;

List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, };

List<int> oddNumberList = new List<int>();
foreach(var number in intList)
{
    if(number % 2 != 0)
    {
        oddNumberList.Add(number);
    }
}

var oddNumbers = intList.Where(x => x % 2 != 0).ToList();

var stringList = new List<string> { "John", "Alex", "Tim", "Bob", "Jane", "Bob", "John" };
var sortedList = stringList.OrderBy(x => x).ToList();

int id = 1;
var students = new List<Student>();
foreach(var name in sortedList)
{
    students.Add(new Student()
    {
        Name = name,
        ID = id,
        IsEnrolled = true,
        Age = id % 2 == 0 ? 22 : 33,       
    });

    id++;
}

var sortedByName = students.OrderBy(x => x.Age).ThenBy(x => x.Name);
foreach(var student in sortedByName)
{
    //Console.WriteLine($"Student name: {student.Name}, Age: {student.Age}");
}

var studentNames = sortedByName.Where(x => x.Age == 22).Select(x => x.Name).ToList();
foreach (var student in studentNames)
{
    //Console.WriteLine($"Student name: {student}");
}

foreach(var student in students)
{
    if(student.ID % 2 == 0)
    {
        student.Address.Add(new Address() {
            Email = "NoReply@Test.ca",
            PhoneNumber = 1234567890
        });
    }
}

var studentsWithAddress = students.OrderByDescending(student => student.ID)
    .Where(student => student.Address != null && 
            student.Address.Where(address => address.Email == "Something").Any())
    .Select(student => student.Address)
    .Select(addressList => addressList.FirstOrDefault());

var studentsAnoutherWay = from student in students //Linq Query
                          where student.ID % 2 == 0
                          orderby student.Name
                          select student;

foreach(var student in studentsAnoutherWay)
{
    //Console.WriteLine(student.Name);
}

var studentsGrouping = students.GroupBy(x => x.Name);

foreach(var grouping in studentsGrouping)
{
    Console.WriteLine(grouping.Key);
    foreach(var student in grouping)
    {
        Console.WriteLine($"Student ID: {student.ID}, StuentName: {student.Name}");
    }
}


Console.ReadLine();
