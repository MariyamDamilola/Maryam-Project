using System.Net.Sockets;
using MaryamProject.Helper;

namespace MaryamProject.Domain;

public class Student : Person
{
 public string StudentId { get; set; }
 public string Course { get; set; }

 public Student(string name, string age, string address, Gender gender)
 {
  Name = name;
  Age = age;
  Address = address;
  Gender = gender;
  
 }
}
