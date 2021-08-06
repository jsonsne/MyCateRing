using DAL.Core;
using MDL;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_AdUsers
    {

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool IsLoginSucee(AdUsers us)
        {
            string sql = "select * from AdUsers where usCode=@code and usPwd=@pwd";
            SqlDataReader sdr = SqlHelp.Query(sql, new SqlParameter("code", us.UsCode), new SqlParameter("pwd", us.UsPwd));
            if (sdr.Read())
                return true;
            return false;

        }

        /// <summary>
        /// 添加操作员
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool AddUsers(AdUsers us)
        {
            if (us.Id == 0)
            {
                string sql = "inset into AdUsers(name,usCode,usPwd) values(@name,@usCode,@usPwd)";
                return SqlHelp.Update(sql, new SqlParameter("name", us.Name), new SqlParameter("usCode", us.UsCode), new SqlParameter("usPwd", us.UsPwd)) > 0;
            }
            else
            {
                string sql = "update AdUsers set name= @name,usCode=@usCode,usPwd=@usPwd where id=@id";
                return SqlHelp.Update(sql, new SqlParameter("name", us.Name), new SqlParameter("usCode", us.UsCode), new SqlParameter("usPwd", us.UsPwd), new SqlParameter("id", us.Id)) > 0;
            }
        }

        /// <summary>
        /// 删除操作员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelUs(int id)
        {
            string sql = "delete AdUsers where id=@id";
            return SqlHelp.Update(sql, new SqlParameter("id", id)) > 0;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<AdUsers> GetUsers()
        {
            List<AdUsers> list = new List<AdUsers>();
            string sql = "select * from AdUsers";
            var sdr = SqlHelp.Query(sql);
            while (sdr.Read())
            {
                AdUsers us = new AdUsers();
                us.Id = (int)sdr[0];
                us.Name = sdr[1].ToString();
                us.UsCode = sdr["usCode"].ToString();
                us.UsPwd = sdr["usPwd"].ToString();
                list.Add(us);
            }
            return list;
        }

    }
}
