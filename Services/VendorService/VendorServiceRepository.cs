using MaryamProject.Domain;
using MaryamProject.Helper;

namespace MaryamProject.Services.VendorService;

public class VendorServiceRepository
{
    
        private static Admin _admin = new Admin();
        private static List<Vendor> _vendors = new List<Vendor>();


        public static bool ValidateAdmin(string adminId, string password)
        {
            return _admin.AdminId == adminId && _admin.Password == password;
        }

    
        //Create Student
        public static void AddVendor(string name, string age, string address, Gender gender)
        {
            string newId = Utils.GetRandomString("VND");
            var newVendor = new Vendor(name, age, address, gender) { VendorId = newId };

            _vendors.Add(newVendor);
        }

        //Get by ID
        public static Vendor GetVendortbyId(string vendorId)
        {
            return _vendors.Find(x => x.VendorId == vendorId);
        }

        //All Vendor
        public static List<Vendor> GetAllVendor()
        {
            return _vendors;
        }
    
        //Update Vendor info
        public static void UpdateVendorInfo(string vendorId, string newAddress, string newAge)
        {
            var vendor = _vendors.Find(x => x.VendorId == vendorId);
            if (vendor != null)
            {
                vendor.Address = newAddress;
                vendor.Age = newAge;
            }
        }
        //Delete Vendor
        public static bool DeleteVendor(string vendorId)
        {
            var vendor = _vendors.Find(x => x.VendorId == vendorId);
            if (vendor != null)
            {
                _vendors.Remove(vendor);
                return true;
            }

            return false;
        }
}