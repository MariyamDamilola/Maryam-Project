using MaryamProject.Domain;
using MaryamProject.Helper;

namespace MaryamProject.Services.LecturerService;

public static class LecturerServiceRepository
{
    private static Admin _admin = new Admin();
        private static List<Lecturer> _lecturers = new List<Lecturer>();


        public static bool ValidateAdmin(string adminId, string password)
        {
            return _admin.AdminId == adminId && _admin.Password == password;
        }

    
        //Create Student
        public static void AddLecturer(string name, string age, string address, Gender gender)
        {
            string newId = Utils.GetRandomString("LEC");
            var newLecturer = new Lecturer(name, age, address, gender) { StaffId = newId };

            _lecturers.Add(newLecturer);
        }

        //Get by ID
        public static Lecturer  GetLecturetbyId(string staffId)
        {
            return _lecturers.Find(x  => x.StaffId == staffId);
        }
        //All students
        public static List<Lecturer> GetAllStaff()
        {
           return _lecturers;
        }
    
        //Update Student info
        public static void UpdateStaffInfo(string staffId, string newAddress, string newAge)
        {
            var lecturer = _lecturers.Find(x => x.StaffId == staffId);
            if (lecturer != null)
            {
                lecturer.Address = newAddress;
                lecturer.Age = newAge;
            }
        }
        //Delete student
        public static bool DeleteLecturer(string staffId)
        {
            var lecturer = _lecturers.Find(x => x.StaffId == staffId);
            if (lecturer != null)
            {
                _lecturers.Remove(lecturer);
                return true;
            }
            return false;

        }
    }
    