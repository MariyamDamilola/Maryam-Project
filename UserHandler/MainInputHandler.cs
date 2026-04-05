namespace MaryamProject.UserHandler;

public static class MainInputHandler
{
    public static void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("==========> UNIVERSITY MANAGEMENT SYSTEM <===========");
            Console.WriteLine("1. Manage students");
            Console.WriteLine("2. Manage Lecturers");
            Console.WriteLine("3. Manage Vendors");
            Console.WriteLine("4. Exit");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StudentUserHandler.Run();
                    break;
                case "2":
                    LecturerUserHandler.Run();
                    break;
                case "3":
                    VendorUserHandler.Run();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    continue;
            }
        }
    }
}