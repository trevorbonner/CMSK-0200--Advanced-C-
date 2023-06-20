using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public interface IConsoleService
    {
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public void SetColor(ConsoleColor background, ConsoleColor foreground);
        public void Update();
        public string ReturnValue();
    }
}
