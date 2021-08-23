using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL;
using DAL;
namespace BLL
{
    public class BLL_CaterBill
    {
        private DAL_CaterBill MyBill;
        public BLL_CaterBill()
        {
            MyBill = new DAL_CaterBill();
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="cater"></param>
        /// <returns></returns>
        public bool AddCaterBill(CaterBill cater) => MyBill.AddCaterBill(cater);

        /// <summary>
        /// 根据餐桌号获取订单信息
        /// </summary>
        /// <param name="tableId"></param>
        /// <returns></returns>
        public CaterBill GetCater(int tableId) => MyBill.GetCater(tableId);

        /// <summary>
        /// 结账完成订单
        /// </summary>
        /// <param name="cater"></param>
        /// <returns></returns>
        public bool UpdateCaterBii(CaterBill cater) => MyBill.UpdateCaterBii(cater);

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <param name="adus"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        public List<BiiConSum> GetConSums(string dateTime1 = null, string dateTime2 = null, string adus = null, string tname = null) => MyBill.GetConSums(dateTime1
            , dateTime2, adus, tname);

        /// <summary>
        /// 账单明细
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public List<TableConSum> GetConSumsDetails(string bid) => MyBill.GetConSumsDetails(bid);


    }
}
