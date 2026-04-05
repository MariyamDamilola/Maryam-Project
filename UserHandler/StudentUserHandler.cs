using System;
using MaryamProject.Domain;
using MaryamProject.Services.StudentService;

namespace MaryamProject.UserHandler;

public static class StudentUserHandler
{
    public static void Run()
    {
        while (true)
        {
            Console.WriteLine("Admin Login");
            Console.WriteLine("------------");
            
            Console.WriteLine("Enter AdminId: ");
            var adminId = Console.ReadLine();
            Console.WriteLine("------------");
            
            Console.WriteLine("Enter Admin Password: ");
            var adminPass = Console.ReadLine();

            if (!(StudentServiceRepository.ValidateAdmin(adminId, adminPass)))
            {
                Console.WriteLine("Admin input");
                return;
            }

            Console.WriteLine("---------------------");
            Console.WriteLine("Login successful");
            
            
            var running = true;
            while (running)
            {
                Console.WriteLine("1. Add Student \n2. Get student by ID \n3. View all students \n4. Update student Information \n5. Delete student \n6.Exit");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Student name: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("----------------------");

                        Console.WriteLine("Student Age: ");
                        var age = Console.ReadLine();
                        Console.WriteLine("-----------------------");
                        
                        Console.WriteLine("Student address: ");
                        var address = Console.ReadLine();
                        Console.WriteLine("-----------------------");
                        
                        Console.WriteLine("Student Gender \n1. Male \n2. Female");
                        var genderchoice = Console.ReadLine();

                        if (!Enum.TryParse(genderchoice, out Gender newGender))
                        {
                            Console.WriteLine("Invalid gender");
                            continue;
                        }
                        
                        //Aad student
                    StudentServiceRepository.AddStudent(name, age, address, newGender);
                        Console.WriteLine("Student successfully added");
                        break;
                    
                    case "2":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Get student by ID");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter student ID to get student: ");
                        string searchId = Console.ReadLine();
                        var student = StudentServiceRepository.GetStudentbyId(searchId);
                        
                        if (student != null)
                        {
                         Console.WriteLine($"Found: {student.Name} | {student.Age} | {student.Address} | {student.Gender}"); 
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                        break;
                    
                    case "3":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Get all student");
                        Console.WriteLine("-------------------");
                        StudentServiceRepository.GetAllStudents();
                        break;
                    
                    case "4":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Update student information");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter student ID to update: ");
                        string idToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter new age: ");
                        string ageToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter new address: ");
                        string addressToUpdate = Console.ReadLine();

                        StudentServiceRepository.UpdateStudent(idToUpdate, ageToUpdate, addressToUpdate);
                        break;
                    
                    case "5":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Delete student");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter student ID to delete student: ");
                        string idToDelete = Console.ReadLine();
                        bool isDeleted = StudentServiceRepository.DeleteStudent(idToDelete);
                        if (isDeleted)
                        {
                            Console.WriteLine("Student successfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Student ID not found");
                        }
                        break;
                    
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}