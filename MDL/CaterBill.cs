using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public class CaterBill
    {
        //id tableId renshu vipId finishDate userId Sumprice IsJieZhang

        public string Id { get; set; }
        public int TableId { get; set; }
        public int Renshu { get; set; }
        public int VipId { get; set; }
        public string FinishDate { get; set; }
        public int UserId { get; set; }
        public double Sumprice { get; set; }
        public bool IsJieZhang { get; set; }

    }
}
