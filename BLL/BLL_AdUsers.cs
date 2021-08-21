using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MDL;

namespace BLL
{
    public class BLL_AdUsers
    {
        private DAL_AdUsers users;
        public BLL_AdUsers()
        {
            users = new DAL_AdUsers();
        }
        /// <summary>
        /// 判断操作员登录
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public AdUsers IsLoginSucees(AdUsers us) => users.IsLoginSucee(us);

        /// <summary>
        /// 添加操作员和修改操作员
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool UpdateUsers(AdUsers us) => users.AddUsers(us);

        /// <summary>
        /// 根据Id删除操作员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelUsers(int id) => users.DelUs(id);


        /// <summary>
        /// 获取所有的操作员信息
        /// </summary>
        /// <returns></returns>
        public List<AdUsers> GetUsers() => users.GetUsers();
    }
}
