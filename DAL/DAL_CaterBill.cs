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

        //账单信息查询
        public List<BiiConSum> GetConSums(string dateTime1 = null, string dateTime2 = null, string adus = null, string tname = null)
        {
            List<BiiConSum> list = new List<BiiConSum>();
            string sql = @"
select b.id bid,d.name tname,b.finishDate,b.SumPrice,v.name vname,u.usCode uname from CaterBill b
join DiTable d
on b.tableId=d.id
join AdUsers u
on u.id=b.userId
left join VipInfo v
on v.id=b.vipId
where b.isJiezhang=1
";
            if (!string.IsNullOrWhiteSpace(adus))
                sql += $" and u.uscode ='{adus}'";
            if (!string.IsNullOrWhiteSpace(tname))
                sql += $" and d.name like'%{adus}%'";
            if (!string.IsNullOrWhiteSpace(dateTime2))
                sql += $" and b.finishDate between '{dateTime1}' and '{dateTime2}'";
            var sdr = SqlHelp.Query(sql);
            while (sdr.Read())
            {
                BiiConSum bii = new BiiConSum();
                bii.Bid = sdr["bid"].ToString();
                bii.Tbname = sdr["tname"].ToString();
                bii.FinishDate = sdr["finishDate"].ToString();
                bii.Sumprice = (double)sdr["sumprice"];
                bii.VipName = string.IsNullOrWhiteSpace(sdr["vname"].ToString()) ? "非会员" : sdr["vname"].ToString();
                bii.Adus = sdr["uname"].ToString();
                list.Add(bii);
            }
            return list;
        }
        //账单明细
        public List<TableConSum> GetConSumsDetails(string bid)
        {
            List<TableConSum> list = new List<TableConSum>();
            string sql = @"
select t.name tname, b.id bid,p.name pname,d.price,d.pCount,b.SumPrice,b.finishDate from CaterBill b
join DiTable t
on t.id=b.tableId
join CaterDetail d
on b.id=d.biiId
join ProductInfo p
on p.id=d.pId
where b.isJiezhang=1 and b.id=@id
";

            var sdr = SqlHelp.Query(sql, new SqlParameter("id", bid));
            while (sdr.Read())
            {
                TableConSum tb = new TableConSum();
                tb.Tname = sdr["tname"].ToString();
                tb.Bid = sdr["bid"].ToString();
                tb.Pname = sdr["pname"].ToString();
                tb.Price = (double)sdr["price"];
                tb.Pcount = (int)sdr["pcount"];
                tb.SumPrice = (double)sdr["sumprice"];
                tb.FinishDate = sdr["finishDate"].ToString();
                list.Add(tb);

            }

            return list;
        }
    }
}
