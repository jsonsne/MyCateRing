using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_Tables
    {
        private ADL_Tables tb;

        public BLL_Tables()
        {
            tb = new ADL_Tables();
        }

        /// <summary>
        /// 根据房间类型Id获取房间内所有的餐桌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Tables> GetTables(int id = 99, int state = 99) => tb.GetTables(id, state);

        /// <summary>
        /// 更新餐桌(添加或者修改)
        /// </summary>
        /// <param name="tbNum"></param>
        /// <returns></returns>
        public bool UpdateTableNum(Tables tbNum) => tb.UpdateTable(tbNum);

        /// <summary>
        /// 删除餐桌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTableNuM(int id) => tb.DeleteTable(id);
    }
}
