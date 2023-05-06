using API.Models;
using System.Security.AccessControl;

namespace API.Data
{
    public class data_for
    {
        public static List<Student> students = new List<Student>(new[]
        {
            new Student() {Id = 1 ,name = "Max", surname = "Vorogushin", age = 18, direction = "Matobes", HS = "VSHKMS"},
        });
    }
}
