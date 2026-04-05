namespace MaryamProject.Domain;

public class Person
{
    public string Name { get; set; }
    public string Age { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; }
    
}

public enum Gender
{
    Male = 1,
    Female = 2
}
//Inheritance: This is a concept that allows