using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModul06;



  class Device
{
    string name;
    string descrip;
    string sound;
    public Device(string name, string descrip, string sound)
    {
        this.name = name;
        this.descrip = descrip;
        this.sound = sound;
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
}
class Kettle : Device
{
    public Kettle(string name, string descrip, string sound) : base(name, descrip, sound) { }
}
class Microwave : Device
{
    public Microwave(string name, string descrip, string sound) : base(name, descrip, sound) { }
}
class Auto : Device
{
    public Auto(string name, string descrip, string sound) : base(name, descrip, sound) { }
}
class Ship : Device
{
    public Ship(string name, string descrip, string sound) : base(name, descrip, sound) { }
}

