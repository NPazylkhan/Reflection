namespace Reflection
{
    public class AgeValidationAttribute : Attribute
    {
        public int Age { get; }
        public AgeValidationAttribute() { }
        public AgeValidationAttribute(int age) => Age = age;
    }

    [AgeValidation(18)]
    public class Person
    {
        public string Name { get; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
