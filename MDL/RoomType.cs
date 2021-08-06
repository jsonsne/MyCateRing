using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public class RoomType
    {
        // insert into RoomType(name, area, isZheKou, minConst, maxRenshu)values('情侣包厢','三楼',0,900,10) id

        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public bool IsZheKou { get; set; }
        public double MinConst { get; set; }
        public int MaxRenshu { get; set; }

    }
}
