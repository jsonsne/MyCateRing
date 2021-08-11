using DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public   class BLL_VipCosts
    {
        DAL_VipCosts vps;
        public BLL_VipCosts()
        {
            vps = new DAL_VipCosts();
        }

        /// <summary>
        /// 查询显示
        /// </summary>
        /// <returns></returns>
        public List<VipCost> GetVipCosts() => vps.GetVipCosts();

        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="vp"></param>
        /// <returns></returns>
        public bool UpdateVipCost(VipCost vp) => vps.UpdateVipCost(vp);

        /// <summary>
        /// 删除等级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteVipCost(int id) => vps.DeleteCost(id);

        /// <summary>
        /// 判断是否存在引用该等级的会员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExistsVipUs(int id) => vps.IsExistsVipUs(id);

    }
}
