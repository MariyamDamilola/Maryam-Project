namespace MaryamProject.Domain;

public class Vendor : Person
{
    public string VendorId { get; set; }
    
    public Vendor(string name, string age, string address, Gender gender)
    {
        Name = name;
        Age = age;
        Address = address;
        Gender = gender;
    }
}