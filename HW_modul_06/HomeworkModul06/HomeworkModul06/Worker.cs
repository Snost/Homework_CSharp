using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModul06
{
    class Worker
    {
        string name;
        string work;
        public Worker(string name, string work)
        {
            this.name = name;
            this.work = work;
        }
        public void Work()
        {
            Console.WriteLine($"I'm {name}. My work is {work}.");
        }
    }
    class President : Worker
    {
        public President(string name, string work) : base(name, work) { }
    }
    class Security : Worker
    {
        public Security(string name, string work) : base(name, work) { }
    }
    class Manager : Worker
    {
        public Manager(string name, string work) : base(name, work) { }
    }
    class Engineer : Worker
    {
        public Engineer(string name, string work) : base(name, work) { }
    }
}


