
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MDL;

namespace BLL
{
    public class BLL_VipUsers
    {
        DAL_VipUsers ADL_Vip;
        public BLL_VipUsers()
        {
            ADL_Vip = new DAL_VipUsers();
        }

        /// <summary>
        /// 查询显示
        /// </summary>
        /// <param name="idOrName"></param>
        /// <returns></returns>
        public List<ShowVipUsers> GetVipUsers(string idOrName = "aaa") => ADL_Vip.GetVipUsers(idOrName);

        /// <summary>
        /// 添加修改
        /// </summary>
        /// <param name="vp"></param>
        /// <returns></returns>
        public bool UpdateVip(VipUsers vp) => ADL_Vip.UpdateVip(vp);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteVipUser(int id) => ADL_Vip.DeleteVipUser(id);

        /// <summary>
        /// 获取会员id，名称，等级名称，折扣率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShowVipUsers GetVipUsers(int id) => ADL_Vip.GetVipUsers(id);

        /// <summary>
        /// 获取会员的消费信息
        /// </summary>
        /// <param name="identityStr"></param>
        /// <returns></returns>
        public List<VipConSum> GetVipConSums(string identityStr=null) => ADL_Vip.GetVipConSums(identityStr);

    }
}
