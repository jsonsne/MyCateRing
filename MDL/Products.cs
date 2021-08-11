using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public class Products
    {
        public int Id { get; set; }
        public int PType { get; set; }
        public string Name { get; set; }
        public string JianPin { get; set; }
        public double Price { get; set; }
        public int State { get; set; }

        public string TypeName { get; set; }
    }
}
