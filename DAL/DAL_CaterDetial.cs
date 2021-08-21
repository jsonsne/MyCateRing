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
    public class DAL_CaterDetial
    {
        //添加
        public int AddCaterDetail(CaterDetail detail)
        {
            string sql = "insert into CaterDetail(biiId,pId,price,pCount,costType,finishDate)values(@billId,@pid,@price,@pcount,@costType,@finishdate)" +
                " select SCOPE_IDENTITY()";

            int vr = Convert.ToInt32(SqlHelp.Scalar(sql,
                new SqlParameter("billId", detail.BiiId),
                new SqlParameter("pid", detail.Pid),
                new SqlParameter("price", detail.Price),
                new SqlParameter("pcount", detail.Pcount),
                new SqlParameter("costType", detail.costType),
                new SqlParameter("finishdate", detail.FinishDate)
                ));
            return vr;
        }
        //删除
        public bool DeleteDetail(int id)
        {
            string sql = "delete CaterDetail where id=@id";
            return SqlHelp.Update(sql, new SqlParameter("id", id)) > 0;
        }
        //显示
        public List<CaterDetail> GetDetails(int tbid = 0)
        {
            //biiId,pId,price,pCount,costType,finishDate
            List<CaterDetail> list = new List<CaterDetail>();
            string sql = @"
select b.id as biiId,b.tableId as tbId,b.SumPrice,d.id,d.pId,d.price,d.pCount,d.costType,d.finishDate,p.name pname,t.name tname from CaterBill b
join CaterDetail d
on b.id=d.biiId
join ProductInfo p
on p.id=d.pId
join ProductType t
on p.pType=t.id
  where isJiezhang=0 ";
            if (tbid != 0)
                sql += " and b.tableId=" + tbid;
            var sdr = SqlHelp.Query(sql);
            while (sdr.Read())
            {
                CaterDetail detail = new CaterDetail();
                detail.Id = (int)sdr["id"];
                detail.BiiId = sdr["biiId"].ToString();
                //string.IsNullOrWhiteSpace(sdr["sumprice"].ToString())?0:(double)sdr["sumprice"];
                detail.Pid = (int)sdr["pid"];
                detail.Price = (double)sdr["price"];
                detail.Pcount = (int)sdr["pcount"];
                detail.costType = (int)sdr["costType"];
                detail.FinishDate = sdr["finishDate"].ToString();
                detail.Pname = sdr["pname"].ToString();
                detail.Tname = sdr["tname"].ToString();
                detail.SumPrice = detail.Pcount * detail.Price;
                list.Add(detail);
            }
            return list;
        }

        //获取订单数量
        public int GetDetailsCount(string biiId)
        {
            string sql = "select COUNT(*) from CaterDetail where biiId=@biiId";
            return Convert.ToInt32(SqlHelp.Scalar(sql, new SqlParameter("biiId", biiId)));
        }
    }
}
