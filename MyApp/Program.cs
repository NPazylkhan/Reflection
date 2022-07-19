using System.Collections.Generic;
using System.Reflection;
using System.Dynamic;

/*Assembly asm = Assembly.LoadFrom("C:\\Users\\nurmakhan.pazylkhan\\source\\repos\\Assembly\\Assembly\\bin\\Debug\\net6.0\\Reflection.dll");

Type? t = asm.GetType("Program");
if (t is not null)
{
    // создаем экземпляр класса Program
    object? obj = Activator.CreateInstance(t);

    // получаем метод Square
    MethodInfo? square = t.GetMethod("Square", BindingFlags.NonPublic | BindingFlags.Static);

    // вызываем метод, передаем ему значения для параметров и получаем результат
    object? result = square?.Invoke(obj, new object[] { 7 });
    Console.WriteLine(result); // 49
}*/

dynamic tom = new Person("Tom", 22);
Console.WriteLine(tom);
Console.WriteLine("Salary is - " + tom.GetSalary(28, "int"));

dynamic bob = new Person("Bob", "twenty-two");
Console.WriteLine(bob);
Console.WriteLine("Salary is - " + bob.GetSalary("twenty-eight", "string"));


// определяем объект, который будет хранять ряд значений
dynamic person = new System.Dynamic.ExpandoObject();
person.Name = "Tom";
person.Age = 46;
person.Languages = new List<string> { "english", "german", "french" };

Console.WriteLine();
Console.WriteLine($"{person.Name} - {person.Age}");

foreach (var lang in person.Languages)
    Console.WriteLine(lang);


var person2 = new PersonRecordModel("Tom");
Console.WriteLine(person2.Name); // Bob - данные изменились

public record PersonRecordModel
{
    public string Name { get; init; }
    public PersonRecordModel(string name) => Name = name;
}

class Person
{
    public string Name { get; }
    public dynamic Age { get; set; }
    public Person(string name, dynamic age)
    {
        Name = name; Age = age;
    }

    // выводим зарплату в зависимости от переданного формата
    public dynamic GetSalary(dynamic value, string format)
    {
        if (format == "string") return $"{value} euro";
        else if (format == "int") return value;
        else return 0.0;
    }

    public override string ToString() => $"Name: {Name}  Age: {Age}";
}