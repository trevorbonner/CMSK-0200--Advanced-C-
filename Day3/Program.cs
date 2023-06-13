
using Day3;

var testList = new List<BaseTestClass>();
var testTuple = new Tuple<int, int>(1, 1);

Console.WriteLine(ForGenerics.ReturnGeneric<BaseTestClass>());
Console.WriteLine(ForGenerics.ReturnGeneric<int>());
Console.WriteLine(ForGenerics.ReturnGeneric<string>());
Console.WriteLine(ForGenerics.ReturnGeneric<bool>());


Console.WriteLine(ForGenerics.ReturnGeneric<bool, int>());
Console.WriteLine(ForGenerics.ReturnGeneric<int, bool>());

var baseList = new List<BaseTestClass>();
baseList.Add(new BaseChildTwo());
baseList.Add(new BaseChildOne());

foreach(var test in baseList)
{
    Console.Write(test.SomeValue());
    Console.WriteLine(test.GetValue());
}

Console.ReadLine();