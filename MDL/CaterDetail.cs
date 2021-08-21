using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public class CaterDetail
    {
        //Id biiId PId price pcount costType finishDate
        public int Id { get; set; }
        public string BiiId { get; set; }
        public int Pid { get; set; }
        public double Price { get; set; }
        public int Pcount { get; set; }
        public int costType { get; set; }
        public string FinishDate { get; set; }
        public string Pname { get; set; }
        public string Tname { get; set; }
        public double SumPrice { get; set; }


    }
}
