using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class ConsoleService : BaseConsoleService, IConsoleService, ISecondInterface
    {
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public string Name { get; set; }

        public override void DoAbstractStuff()
        {
            throw new NotImplementedException();
        }

        public string ReturnValue()
        {
            return "This is from Console Service";
        }

        public void SetColor(ConsoleColor background, ConsoleColor foreground)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
