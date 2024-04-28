using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModul06
{
    class MusicInstrument
    {
        string name;
        string descrip;
        string sound;
        string history;
        public MusicInstrument(string name, string descrip, string sound, string history)
        {
            this.name = name;
            this.descrip = descrip;
            this.sound = sound;
            this.history = history;
        }
        public void Show()
        {
            Console.Write(name);
        }
        public void Desc()
        {
            Console.Write(descrip);
        }
        public void Sound()
        {
            Console.Write(sound);
        }
        public void History()
        {
            Console.Write(history);
        }
    }
    class Violin : MusicInstrument
    {
        public Violin(string name, string descrip, string sound, string history) : base(name, descrip, sound, history) { }
    }
    class Trombone : MusicInstrument
    {
        public Trombone(string name, string descrip, string sound, string history) : base(name, descrip, sound, history) { }
    }
    class Ukulele : MusicInstrument
    {
        public Ukulele(string name, string descrip, string sound, string history) : base(name, descrip, sound, history) { }
    }
    class Violoncello : MusicInstrument
    {
        public Violoncello(string name, string descrip, string sound, string history) : base(name, descrip, sound, history) { }
    }
}
    

