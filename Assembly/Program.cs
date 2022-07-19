using Reflection;
using System.Reflection;


/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("1)");

Type myType2 = typeof(Person);
Console.WriteLine(myType2);  // Person

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("2)");

Type? myType = Type.GetType("PeopleTypes.Person", false, true);
Console.WriteLine(myType);  // PeopleTypes.Person
Console.WriteLine($"Name: {myType.Name}");              // получаем краткое имя типа
Console.WriteLine($"Full Name: {myType.FullName}");     // получаем полное имя типа
Console.WriteLine($"Namespace: {myType.Namespace}");    // получаем пространство имен типа
Console.WriteLine($"Is struct: {myType.IsValueType}");  // является ли тип структурой
Console.WriteLine($"Is class: {myType.IsClass}");       // является ли тип классом

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("3)");

Type myType3 = typeof(Person2);
Console.WriteLine("Реализованные интерфейсы:");
foreach (Type i in myType3.GetInterfaces())
{
    Console.WriteLine(i.Name);
}

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("4)");
Type myType4 = typeof(GetMembers);

foreach (MemberInfo member in myType4.GetMembers())
{
    Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
}

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("5)");

Type myType5 = typeof(GetMembers);

foreach (MemberInfo member in myType5.GetMembers(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
{
    Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
}


/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("6)0000000");
Type myType6 = typeof(Printer);

Console.WriteLine("Методы:");
foreach (MethodInfo method in myType6.GetMethods()
                                     .Where(m => !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_")))
{
    string modificator = "";

    // если метод статический
    if (method.IsStatic) modificator += "static ";
    // если метод виртуальный
    if (method.IsVirtual) modificator += "virtual ";

    Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name} ()");
}

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("7)");

Type myType7 = typeof(Printer);

Console.WriteLine("Методы:");
foreach (MethodInfo method in myType7.GetMethods(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
{
    Console.WriteLine($"{method.ReturnType.Name} {method.Name} ()");
}

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("8)");

foreach (MethodInfo method in typeof(Printer3).GetMethods())
{
    Console.Write($"{method.ReturnType.Name} {method.Name} (");
    //получаем все параметры
    ParameterInfo[] parameters = method.GetParameters();
    for (int i = 0; i < parameters.Length; i++)
    {
        var param = parameters[i];
        // получаем модификаторы параметра
        string modificator = "";
        if (param.IsIn) modificator = "in";
        else if (param.IsOut) modificator = "out";

        Console.Write($"{param.ParameterType.Name} {modificator} {param.Name}");
        // если параметр имеет значение по умолчанию
        if (param.HasDefaultValue) Console.Write($"={param.DefaultValue}");
        // если не последний параметр, добавляем запятую
        if (i < parameters.Length - 1) Console.Write(", ");
    }
    Console.WriteLine(")");
}

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("9)");
var myPrinter = new Printer("Hello");

// получаем метод Print
var print = typeof(Printer).GetMethod("Print");
// вызываем метод Print
print?.Invoke(myPrinter, parameters: null); // Hello


var print2 = typeof(Printer).GetMethod("Print2",
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);
// вызываем метод Print
print2?.Invoke(myPrinter, parameters: null); // Hello METANIT.COM


var print3 = typeof(Printer).GetMethod("PrintMessage");
// вызываем метод Print
print3?.Invoke(myPrinter, new object[] { "Hi world", 3 }); // Hello

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("10)");

Type myType10 = typeof(PersonCtor);

Console.WriteLine("Конструкторы:");
foreach (ConstructorInfo ctor in myType10.GetConstructors(
    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
{
    string modificator = "";

    // получаем модификатор доступа
    if (ctor.IsPublic)
        modificator += "public";
    else if (ctor.IsPrivate)
        modificator += "private";
    else if (ctor.IsAssembly)
        modificator += "internal";
    else if (ctor.IsFamily)
        modificator += "protected";
    else if (ctor.IsFamilyAndAssembly)
        modificator += "private protected";
    else if (ctor.IsFamilyOrAssembly)
        modificator += "protected internal";

    Console.Write($"{modificator} {myType.Name}(");
    // получаем параметры конструктора
    ParameterInfo[] parameters = ctor.GetParameters();
    for (int i = 0; i < parameters.Length; i++)
    {
        var param = parameters[i];
        Console.Write($"{param.ParameterType.Name} {param.Name}");
        if (i < parameters.Length - 1) Console.Write(", ");
    }
    Console.WriteLine(")");
}
Console.WriteLine();
Console.WriteLine("Поля:");
foreach (FieldInfo field in myType10.GetFields(
    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
{
    string modificator = "";

    // получаем модификатор доступа
    if (field.IsPublic)
        modificator += "public ";
    else if (field.IsPrivate)
        modificator += "private ";
    else if (field.IsAssembly)
        modificator += "internal ";
    else if (field.IsFamily)
        modificator += "protected ";
    else if (field.IsFamilyAndAssembly)
        modificator += "private protected ";
    else if (field.IsFamilyOrAssembly)
        modificator += "protected internal ";

    // если поле статическое
    if (field.IsStatic) modificator += "static ";

    Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
}

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// Получение и изменение значения поля
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("11)");

Type myType11 = typeof(PersonVariables);
PersonVariables tom = new PersonVariables("Tom", 37);

// получаем приватное поле name
var name = myType11.GetField("name", BindingFlags.Instance | BindingFlags.NonPublic);

// получаем значение поля name
var value = name?.GetValue(tom);
Console.WriteLine(value);   // Tom

// изменяем значение поля name
name?.SetValue(tom, "Bob");
tom.Print();    // Bob - 37

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine(new String('-', 25));
Console.WriteLine("12)");
Reflection.Person tom1 = new Reflection.Person("Tom", 35);
Reflection.Person bob1 = new Reflection.Person("Bob", 16);
bool tomIsValid = ValidateUser(tom1);    // true
bool bobIsValid = ValidateUser(bob1);    // false

Console.WriteLine($"Результат валидации Тома: {tomIsValid}");
Console.WriteLine($"Результат валидации Боба: {bobIsValid}");

bool ValidateUser(Reflection.Person person)
{
    Type type = typeof(Reflection.Person);
    // получаем все атрибуты класса Person
    object[] attributes = type.GetCustomAttributes(false);

    // проходим по всем атрибутам
    foreach (Attribute attr in attributes)
    {
        // если атрибут представляет тип AgeValidationAttribute
        if (attr is AgeValidationAttribute ageAttribute)
            // возвращаем результат проверки по возрасту
            return person.Age >= ageAttribute.Age;
    }
    return true;
}


#region classes

public class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}



namespace PeopleTypes
{
    public class Person
    {
        public string Name { get; }
        public Person(string name) => Name = name;
    }
}

public class Person2 : IEater, IMovable
{
    public string Name { get; }
    public Person2(string name) => Name = name;
    public void Eat() => Console.WriteLine($"{Name} eats");

    public void Move() => Console.WriteLine($"{Name} moves");
}
interface IEater
{
    void Eat();
}
interface IMovable
{
    void Move();
}

namespace Reflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            var number = 5;
            var result = Square(number);
            Console.WriteLine($"Квадрат {number} равен {result}");
        }
        static int Square(int n) => n * n;
    }
}
#endregion