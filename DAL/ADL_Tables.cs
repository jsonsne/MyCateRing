using DAL.Core;
using MDL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ADL_Tables
    {
        /// <summary>
        /// 根据房间类型Id获取房间内所有的餐桌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Tables> GetTables(int id = 99, int state = 99)
        {
            List<Tables> list = new List<Tables>();
            string sql = "select * from DiTable where 1=1 ";
            if (id != 99)
                sql += $" and roomid={id}";
            if (state != 99)
                sql += $" and states={state}";
            using (var sdr = SqlHelp.Query(sql))
            {
                while (sdr.Read())
                {
                    Tables tb = new Tables()
                    {
                        Id = (int)sdr["id"],
                        Name = sdr["name"].ToString(),
                        Rid = (int)sdr["roomid"],
                        State = (int)sdr["states"]
                    };
                    list.Add(tb);
                }
            }
            return list;
        }

        /// <summary>
        /// 更新餐桌(添加或者修改)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>

        public bool UpdateTable(Tables tb)
        {
            if (tb.Id != 0)
            {
                string sql = "update DiTable set name=@name,roomId=@rid,states=@state where id=@id";
                return SqlHelp.Update(sql, new SqlParameter("name", tb.Name),
                   new SqlParameter("rid", tb.Rid), new SqlParameter("state", tb.State), new SqlParameter("id", tb.Id)) > 0;
            }
            else
            {
                string sql = "insert into DiTable(name,roomId,states)values(@name,@rid,@state)";
                return SqlHelp.Update(sql, new SqlParameter("name", tb.Name),
                    new SqlParameter("rid", tb.Rid), new SqlParameter("state", tb.State)) > 0;
            }
        }

        /// <summary>
        /// 删除餐桌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTable(int id)
        {
            string sql = "delete DiTable where id=@id";
            return SqlHelp.Update(sql, new SqlParameter("id", id)) > 0;
        }

    }
}
