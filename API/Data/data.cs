using API.Models;
using System.Security.AccessControl;

namespace API.Data
{
    public class data_for
    {
        public static List<Product> products = new List<Product>(new[]
        {
            new Product() {Id = 1, Name = "Qwert", Price = 1234},
        });
    }
}
