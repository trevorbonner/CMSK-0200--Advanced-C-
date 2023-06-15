using Day4;

var testList1 = new GenericTestList<int>();
testList1.Add(1);
testList1.Add(2);
testList1.Remove(2);
var number = testList1.CreateNew();

var testListString = new GenericTestList<string>();
testListString.Add("1");
testListString.Add("2");
testListString.Add("3");
testListString.Remove("1");
var newString = testListString.CreateNew();

Console.ReadLine();
