using MaryamProject.Domain;
using MaryamProject.Services.VendorService;

namespace MaryamProject.UserHandler;

public class VendorUserHandler
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

            if (!(VendorServiceRepository.ValidateAdmin(adminId, adminPass)))
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
                    "1. Add Vendor \n2. Get Vendor by ID \n3. View all VendorS \n4. Update Vendor Information \n5. Delete Vendor \n6.Exit");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Vendor name: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("----------------------");

                        Console.WriteLine("Vendor Age: ");
                        var age = Console.ReadLine();
                        Console.WriteLine("-----------------------");

                        Console.WriteLine("Vendor address: ");
                        var address = Console.ReadLine();
                        Console.WriteLine("-----------------------");

                        Console.WriteLine("Vendor Gender \n1. Male \n2. Female");
                        var genderchoice = Console.ReadLine();

                        if (!Enum.TryParse(genderchoice, out Gender newGender))
                        {
                            Console.WriteLine("Invalid gender");
                            continue;
                        }

                        //Add student
                        string VendorID = VendorServiceRepository.AddVendor(name, age, address, newGender);
                        Console.WriteLine($"Vendor successfully added!\n Name: {name}\n Age: {age}\n Address: {address}\n Gender: {newGender}\n VendorID: {VendorID}");
                        break;

                    case "2":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Vendor");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter Vendor ID to get lecturer: ");
                        var searchId = Console.ReadLine();
                        var Vendor = VendorServiceRepository.GetVendortbyId(searchId);

                        if (Vendor != null)
                        {
                            Console.WriteLine(
                                $"Found: Name: {Vendor.Name} \nAge: {Vendor.Age} \nAddress: {Vendor.Address} \nGender: {Vendor.Gender} \nStudentID: {Vendor.VendorId}");
                        }
                        else
                        {
                            Console.WriteLine("Vendor not found");
   
                        }

                        break;

                    case "3":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Get all Lecturers");
                        Console.WriteLine("-------------------");
                        var allVendor = VendorServiceRepository.GetAllVendor();
                        if (allVendor.Count == 0)
                        {
                            Console.WriteLine("No students found");
                        }
                        else
                        {
                            foreach (var v in allVendor)
                            {
                                Console.WriteLine(
                                    $" Name: {v.Name}\n Age: {v.Age}\n Address: {v.Address}\nGender: {v.Gender}\nStudendID: {v.VendorId}");
                            }
                        }

                        break;
                            case "4":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Update Vendor information");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter Vendor ID to update: ");
                        string idToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter new age: ");
                        string ageToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter new address: ");
                        string addressToUpdate = Console.ReadLine();

                        bool UpdateSuccess = VendorServiceRepository.UpdateVendorInfo(idToUpdate, ageToUpdate, addressToUpdate);
                        if (UpdateSuccess)
                        {
                            Console.WriteLine("Vendor information successfully Updated");
                        }
                        else
                        {
                            Console.WriteLine("Update failed");

                        }
                        break;

                    case "5":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Delete Vendor");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter Vendor ID to delete student: ");
                        var idToDelete = Console.ReadLine();
                        bool isDeleted = VendorServiceRepository.DeleteVendor(idToDelete);
                        if (isDeleted)
                        {
                            Console.WriteLine("Vendor successfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Vendor ID not found");
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