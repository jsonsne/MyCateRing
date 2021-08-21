using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.Core;
using MDL;
namespace DAL
{
    public class DAL_RoomType
    {

        /// <summary>
        /// 查询获取房间类型
        /// </summary>
        /// <returns></returns>
        public List<RoomType> GetRoomTypes()
        {
            List<RoomType> list = new List<RoomType>();
            string sql = "select * from RoomType ";
            using (var sdr = SqlHelp.Query(sql))
            {
                while (sdr.Read())
                {
                    RoomType r = new RoomType();
                    r.Id = (int)sdr["id"];
                    r.Name = sdr["name"].ToString();
                    r.Area = sdr["area"].ToString();
                    r.IsZheKou = (bool)sdr["isZheKou"];
                    r.MinConst = (int)sdr["minConst"];
                    r.MaxRenshu = (int)sdr["maxRenshu"];

                    list.Add(r);
                }
            }
            return list;
        }

        /// <summary>
        /// 添加和修改
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public bool Update(RoomType room)
        {
            if (room.Id == 0)
            {
                //添加
                //insert into RoomType(name,area,isZheKou,minConst,maxRenshu)values('情侣包厢','三楼',0,900,10)
                string sql = "insert into RoomType(name,area,isZheKou,minConst,maxRenshu)values(@name,@area,@isZhekou,@minConst,@maxRenshu)";
                return SqlHelp.Update(sql,
                    new SqlParameter("name", room.Name),
                    new SqlParameter("area", room.Area),
                    new SqlParameter("isZhekou", room.IsZheKou),
                    new SqlParameter("minConst", room.MinConst),
                    new SqlParameter("maxRenshu", room.MaxRenshu)
                    ) > 0;
            }
            else
            {
                //修改
                string sql = "update RoomType set name=@name,area=@area,isZheKou=@isZheKou,minConst=@minConst,maxRenshu=@maxRenshu where id=@id";
                return SqlHelp.Update(sql,
                    new SqlParameter("name", room.Name),
                    new SqlParameter("area", room.Area),
                    new SqlParameter("isZhekou", room.IsZheKou),
                    new SqlParameter("minConst", room.MinConst),
                    new SqlParameter("maxRenshu", room.MaxRenshu),
                    new SqlParameter("id", room.Id)
                    ) > 0;
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRoom(int id)
        {
            string sql = "delete RoomType where id=@id";
            return SqlHelp.Update(sql, new SqlParameter("id", id)) > 0;
        }


        /// <summary>
        /// 获取房间类型下的餐桌数量(删除时用来判断：如果存在餐桌的房间不允许删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ByIdRoomCount(int id)
        {
            string sql = @"
 select count(*) from RoomType r 
 join DiTable t
 on r.id =t.roomId
 where r.id=@id
";
            using (var sdr = SqlHelp.Query(sql, new SqlParameter("id", id)))
            {
                if (sdr.Read())
                {
                    return (int)sdr[0]>0;
                }
            }
            return false;
        }

    }
}
