namespace MaryamProject.Domain;

public class Lecturer : Person
{
    public string StaffId { get; set; }

    public Lecturer(string name, string age, string address, Gender gender)
    {
        Name = name;
        Age = age;
        Address = address;
        Gender = gender;
    }

}