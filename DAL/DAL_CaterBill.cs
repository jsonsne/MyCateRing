using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Core;
using MDL;
namespace DAL
{
    public class DAL_CaterBill
    {


        //添加订单
        public bool AddCaterBill(CaterBill cater)
        {
            string sql = "insert into CaterBill(id,tableId,renShu,userId)values(@id,@tableId,@renshu,@userId)";
            return SqlHelp.Update(sql,
                new SqlParameter("id", cater.Id),
                new SqlParameter("tableId", cater.TableId),
                new SqlParameter("renshu", cater.Renshu),
                new SqlParameter("userId", cater.UserId)
                ) > 0;
        }

        //根据餐桌号查询订单
        public CaterBill GetCater(int tableId)
        {
            CaterBill bill = new CaterBill();
            string sql = "select * from CaterBill where tableId=@tId and isJiezhang=0";
            var sdr = SqlHelp.Query(sql, new SqlParameter("tId", tableId));
            while (sdr.Read())
            {
                bill.Id = sdr["id"].ToString();
                bill.Renshu = (int)sdr["renshu"];
                bill.Sumprice = string.IsNullOrWhiteSpace(sdr["sumPrice"].ToString()) ? 0 : (int)sdr["sumPrice"];
                bill.TableId = int.Parse(sdr["tableID"].ToString());
                bill.UserId = (int)sdr["userId"];
                bill.VipId = string.IsNullOrWhiteSpace(sdr["vipId"].ToString()) ? 0 : (int)sdr["vipId"];
                bill.IsJieZhang = (bool)sdr["isJiezhang"];
                bill.FinishDate = string.IsNullOrWhiteSpace(sdr["finishDate"].ToString()) ? "" : sdr["finishDate"].ToString();
            }
            return bill;
        }
        //修改
        public bool UpdateCaterBii(CaterBill cater)
        {
            string sql = "update CaterBill set vipId=@vid,finishDate=@date,SumPrice=@sumprice,isJiezhang=1 where id=@id";
            return SqlHelp.Update(sql,
                new SqlParameter("vid", cater.VipId),
                new SqlParameter("date", cater.FinishDate),
                new SqlParameter("sumprice", cater.Sumprice),
                new SqlParameter("id", cater.Id)
                ) > 0;
        }

    }
}
