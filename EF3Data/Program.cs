using EF3Data.Data;
using System.Globalization;

namespace EF3Data
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var name = "TrevorBonner123@gmail.ca";
            var dataCreator = new DataCreator(name);
            var container = dataCreator.GetData();
            Console.WriteLine("Hello, World!");
        }
    }
}