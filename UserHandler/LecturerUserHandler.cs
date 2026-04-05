using MaryamProject.Domain;
using MaryamProject.Services.LecturerService;

namespace MaryamProject.UserHandler;

public static class LecturerUserHandler
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

            if (!(LecturerServiceRepository.ValidateAdmin(adminId, adminPass)))
            {
                Console.WriteLine("Invalid Admin input");
                return;
            }

            Console.WriteLine("---------------------");
            Console.WriteLine("Login successful");


            var running = true;
            while (running)
            {
                Console.WriteLine(
                    "1. Add Lecturer \n2. Get staff by ID \n3. View all Lecturers \n4. Update Lecturer Information \n5. Delete Lecturer \n6. Exit");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Lecturer name: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("----------------------");

                        Console.WriteLine("Lecturer Age: ");
                        var age = Console.ReadLine();
                        Console.WriteLine("-----------------------");

                        Console.WriteLine("Lecturer address: ");
                        var address = Console.ReadLine();
                        Console.WriteLine("-----------------------");

                        Console.WriteLine("Lecturer Gender \n1. Male \n2. Female");
                        var genderchoice = Console.ReadLine();

                        if (!Enum.TryParse(genderchoice, out Gender newGender))
                        {
                            Console.WriteLine("Invalid gender");
                            continue;
                        }

                        //Add student
                        string StaffId = LecturerServiceRepository.AddLecturer(name, age, address, newGender);
                        Console.WriteLine(
                            $"Student successfully added!\n Name: {name}\n Age: {age}\n Address: {address}\n Gender: {newGender}\n StudentID: {StaffId}");
                        break;

                    case "2":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("All Lecturer");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter Lecturer ID to get lecturer: ");
                        string searchId = Console.ReadLine();
                        var Lecturer = LecturerServiceRepository.GetLecturetbyId(searchId);

                        if (Lecturer != null)
                        {
                            Console.WriteLine(
                                $"Found \nName: {Lecturer.Name} \nAge: {Lecturer.Age} \nAddress: {Lecturer.Address} \nGender: {Lecturer.Gender} \nStaffID: {Lecturer.StaffId}");
                        }
                        else
                        {
                            Console.WriteLine("Lecturer not found");
                        }

                        break;

                    case "3":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("All Lecturers");
                        Console.WriteLine("-------------------");
                        var allStaff = LecturerServiceRepository.GetAllStaff();
                        if (allStaff.Count == 0)
                        {
                            Console.WriteLine("No Lecturer found");
                        }
                        else
                        {
                            foreach (var l in allStaff)
                            {
                                Console.WriteLine(
                                    $" Name: {l.Name}\n Age: {l.Age}\n Address: {l.Address}\nGender: {l.Gender} \nStudentID: {l.StaffId}");
                            }
                        }

                        break;

                    case "4":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Update Lecturer information");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter Lecturer ID to update: ");
                        string idToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter new age: ");
                        string ageToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter new address: ");
                        string addressToUpdate = Console.ReadLine();

                        bool UpdateSuccess =
                            LecturerServiceRepository.UpdateStaffInfo(idToUpdate, ageToUpdate, addressToUpdate);
                        if (UpdateSuccess)
                        {
                            Console.WriteLine("Lecturer information successfully Updated");
                        }
                        else
                        {
                            Console.WriteLine("Update failed");
                        }

                        break;

                    case "5":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Delete Lecturer");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter Lecturer ID to delete student: ");
                        string idToDelete = Console.ReadLine();
                        bool isDeleted = LecturerServiceRepository.DeleteLecturer(idToDelete);
                        if (isDeleted)
                        {
                            Console.WriteLine("Lecturer successfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Lecturer ID not found");
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
