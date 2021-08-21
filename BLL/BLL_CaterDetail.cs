using DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_CaterDetail
    {
        DAL_CaterDetial caterDetial;
        public BLL_CaterDetail()
        {
            caterDetial = new DAL_CaterDetial();
        }

        /// <summary>
        /// 添加订单详细
        /// </summary>
        /// <param name="cater"></param>
        /// <returns></returns>
        public int AddCaterDetail(CaterDetail cater) => caterDetial.AddCaterDetail(cater);

        /// <summary>
        /// 删除订单详细
        /// </summary>
        /// <param name="biiId"></param>
        /// <returns></returns>
        public bool DeleteDetail(int biiId) => caterDetial.DeleteDetail(biiId);

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<CaterDetail> GetCaters(int tbId=0) => caterDetial.GetDetails(tbId);

        /// <summary>
        /// 获取订单数量
        /// </summary>
        /// <param name="biiId"></param>
        /// <returns></returns>
        public int GetDetailsCount(string biiId) => caterDetial.GetDetailsCount(biiId);
    }
}
