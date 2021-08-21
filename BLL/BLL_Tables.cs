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
        private DAL_Tables tb;

        public BLL_Tables()
        {
            tb = new DAL_Tables();
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

        /// <summary>
        /// 显示所有的房间餐桌
        /// </summary>
        /// <returns></returns>
        public List<TempTableRomm> GetRommTypes(string str) => tb.GetRommTypes(str);

        /// <summary>
        /// 获取餐桌的状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetTableState(int id) => tb.GetTableState(id);

        //根据餐桌Id获取具体的信息
        public Tables GetTable(int id) => tb.GetTable(id);


        /// <summary>
        /// 开台
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Kaitans GetKaitans(int id) => tb.GetKaitans(id);

        /// <summary>
        /// 更改餐桌状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateTableState(int state,int id) => tb.UpdateState(state,id);
    }
}
