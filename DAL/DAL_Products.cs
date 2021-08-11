using DAL.Core;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_Products
    {
        //获取所有的商品信息
        public List<Products> GetProducts(int t = 0, string str = "aa")
        {
            List<Products> list = new List<Products>();
            string sql = @"
select p.id,p.name as pName,t.name tName,price,p.jianpin,p.pType,p.state from ProductInfo p
join ProductType t
on p.pType=t.id
where p.state=0
";

            if (t != 0)
                sql += $" and ptype={t}";
            if (str != "aa")
                sql += $" and jianpin like'%{str}%'";

            var sdr = SqlHelp.Query(sql);
            while (sdr.Read())
            {
                Products p = new Products();
                p.Id = (int)sdr["id"];
                p.Name = sdr["pName"].ToString();
                p.JianPin = sdr["jianpin"].ToString();
                p.Price = (double)sdr["price"];
                p.PType = (int)sdr["ptype"];
                p.State = (int)sdr["state"];
                p.TypeName = sdr["tName"].ToString();
                list.Add(p);
            }
            return list;
        }

        //更新商品(添加或者修改)

        public bool UpdateProducts(Products ps)
        {
            if (ps.Id != 0)
            {
                string sql = "update ProductInfo set name=@name,jianpin=@jianpin,price=@price,ptype=@ptype where id=@id";
                return SqlHelp.Update(sql,
                    new SqlParameter("name", ps.Name),
                    new SqlParameter("jianpin", ps.JianPin),
                    new SqlParameter("price", ps.Price),
                    new SqlParameter("ptype", ps.PType),
                    new SqlParameter("id", ps.Id)

                    ) > 0;
            }
            else
            {
                string sql = "insert into ProductInfo(name,jianpin,price,ptype)values(@name,@jianpin,@price,@ptype)";
                return SqlHelp.Update(sql, new SqlParameter("name", ps.Name),
                    new SqlParameter("jianpin", ps.JianPin),
                    new SqlParameter("price", ps.Price),
                    new SqlParameter("ptype", ps.PType)
                    ) > 0;
            }
        }

        //删除商品(只做下架操作，不做物理删除)
        public bool DeleteProduct(int id)
        {
            string sql = "update ProductInfo set state=1 where id=@id";
            return SqlHelp.Update(sql, new SqlParameter("id", id)) > 0;
        }

    }
}
