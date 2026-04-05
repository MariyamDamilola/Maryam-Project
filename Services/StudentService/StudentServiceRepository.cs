using MaryamProject.Domain;
using MaryamProject.Helper;

namespace MaryamProject.Services.StudentService;

public static class StudentServiceRepository
{
    private static Admin _admin = new Admin();
    private static List<Student> _students = new List<Student>();


    public static bool ValidateAdmin(string adminId, string password)
    {
        return _admin.AdminId == adminId && _admin.Password == password;
    }

    
    //Create Student
    public static string AddStudent(string name, string age, string address, Gender gender)
    {
        string newId = Utils.GetRandomString("STD");
        var newStudent = new Student(name, age, address, gender) { StudentId = newId };

       _students.Add(newStudent);
       return newId;
    }

    //Get by ID
    public static Student  GetStudentbyId(string studentId)
    {
        return _students.Find(x  => x.StudentId == studentId);
    }
    //All students
    public static List<Student> GetAllStudents()
    {
        return _students;
    }
    
    //Update Student info
    public static bool UpdateStudent(string studentId, string newAge, string newAddress)
    {
        var student = _students.Find(x => x.StudentId == studentId);
        if (student != null)
        {
            student.Address = newAddress;
            student.Age = newAge;
            return true;
        }

        return false;
    }
    //Delete student
    public static bool DeleteStudent(string studentId)
    {
        var student = _students.Find(x => x.StudentId == studentId);
        if (student != null)
        {
            _students.Remove(student);
            return true;
        }
        return false;

    }
}
