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
    public class DAL_Tables
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

        //显示所有的房间餐桌
        public List<TempTableRomm> GetRommTypes(string rName)
        {
            List<TempTableRomm> list = new List<TempTableRomm>();
            string sql = @"
select d.id,d.name,r.name as tName,d.states from DiTable d
join RoomType r
on d.roomId=r.id
where 1=1 ";
            if (!string.IsNullOrWhiteSpace(rName) && rName != "全部")
                sql += " and  r.name='" + rName + "'";
            var sdr = SqlHelp.Query(sql);
            while (sdr.Read())
            {
                TempTableRomm t = new TempTableRomm();
                t.Id = (int)sdr["id"];
                t.TName = sdr["tName"].ToString();
                t.RName = sdr["name"].ToString();
                t.State = ((TableEnum)((int)sdr["states"])).ToString();
                list.Add(t);
            }
            return list;
        }

        //获取餐桌的使用状态
        public string GetTableState(int id)
        {
            string sql = "select states from DiTable where id=@id";
            var sdr = SqlHelp.Query(sql, new SqlParameter("id", id));
            if (sdr.Read())
                return ((TableEnum)(int)sdr[0]).ToString();
            return null;
        }

        //根据餐桌Id获取具体的信息
        public Tables GetTable(int id)
        {
            Tables t = new Tables();
            string sql = "select * from DiTable where id=@id";
            var sdr = SqlHelp.Query(sql, new SqlParameter("id", id));
            while (sdr.Read())
            {
                t.Id = (int)sdr["id"];
                t.Name = sdr["name"].ToString();
                t.Rid = (int)sdr["roomid"];
                t.State = (int)sdr["states"];
            }
            return t;
        }

        //餐桌开台
        public Kaitans GetKaitans(int id)
        {
            string sql = @"
select dt.id as tbid ,dt.name tbName,rt.id as tyId,rt.name as tyName,rt.minConst ,rt.maxRenshu from DiTable dt
join RoomType rt 
on dt.roomId=rt.id
where dt.id=@id
";
            Kaitans kaitans = new Kaitans();
            var sdr = SqlHelp.Query(sql, new SqlParameter("id", id));
            while (sdr.Read())
            {
                kaitans.TbId = (int)sdr["tbid"];
                kaitans.TyId = (int)sdr["tyid"];
                kaitans.TbName = sdr["tbname"].ToString();
                kaitans.TyName = sdr["tyname"].ToString();
                kaitans.TyMinCost = (int)sdr["minConst"];
                kaitans.TyMaxRenshu = (int)sdr["maxrenshu"];
            }
            return kaitans;
        }

        //餐桌状态的改变
        public bool UpdateState(int state, int id)
        {
            string sql = "update DiTable set states=@state where id=@id";
            return SqlHelp.Update(sql, new SqlParameter("state", state), new SqlParameter("id", id)) > 0;
        }


    }
}
