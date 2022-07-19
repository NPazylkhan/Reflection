using System.Reflection;     // подключаем функционал рефлексии

namespace Reflection
{
    public class GetMembers { 
  
    string name;
    public int Age { get; set; }
    public GetMembers(string name, int age)
    {
        this.name = name;
        this.Age = age;
    }
    public void Print() => Console.WriteLine($"Name: {name} Age: {Age}");

    }

    class Printer
    {
        public Printer(string DefaultMessage)
        {
            this.DefaultMessage = DefaultMessage;
        }
        public string DefaultMessage { get; set; } = "Hello";
        public void PrintMessage(string message, int times = 1)
        {
            while (times-- > 0) Console.WriteLine(times + " " + message);
        }
        public string CreateMessage() => DefaultMessage;
        public void Print() => Console.WriteLine($"Message: {DefaultMessage}");
        public void Print2() => Console.WriteLine($"Message: {DefaultMessage}");

    }

    class Printer2
    {
        public string DefaultMessage { get; set; } = "Hello";
        protected internal void PrintMessage(string message, int times = 1)
        {
            while (times-- > 0) Console.WriteLine(message);
        }
        private string CreateMessage() => DefaultMessage;
    }

    class Printer3
    {
        public void PrintMessage(string message, int times = 1)
        {
            while (times-- > 0) Console.WriteLine(message);
        }
        public void CreateMessage(out string message) => message = "Hello Metanit.com";
    }

    class PersonCtor
    {
        public string Name { get; }
        public int Age { get; }
        public PersonCtor(string name, int age)
        {
            Name = name; Age = age;
        }
        public PersonCtor(string name) : this(name, 1) { }
        private PersonCtor() : this("Tom") { }
    }

    class PersonVariables
    {
        static int minAge = 1;
        string name;
        int age;
        public PersonVariables(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void Print() => Console.WriteLine($"{name} - {age}");
    }
}
