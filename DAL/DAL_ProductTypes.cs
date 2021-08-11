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
    public class DAL_ProductTypes
    {
        //获取所有的商品类型
        public List<ProductTypes> GetProductTypes()
        {
            List<ProductTypes> list = new List<ProductTypes>();
            string sql = "select * from ProductType";
            var sdr = SqlHelp.Query(sql);
            while (sdr.Read())
            {
                ProductTypes pt = new ProductTypes();
                pt.Id = (int)sdr["id"];
                pt.Name = sdr["name"].ToString();
                list.Add(pt);
            }
            return list;
        }

        //更新商品类型(添加或修改)
        public bool UpdateType(ProductTypes product)
        {
            if (product.Id != 0)
            {
                string sql = "update ProductType set name=@name where id=@id ";
                return SqlHelp.Update(sql, new SqlParameter("name", product.Name), new SqlParameter("id", product.Id)) > 0;
            }
            else
            {
                string sql = "insert into ProductType(name) values(@name)";
                return SqlHelp.Update(sql, new SqlParameter("name", product.Name)) > 0;
            }
        }

        //根据Id删除商品类型
        public bool DeleteType(int id)
        {
            string sql = "delete ProductType where id=@id";
            return SqlHelp.Update(sql, new SqlParameter("id", id)) > 0;
        }


        //判断删除时该商品类型是否包含商品
        public bool HasProduct(int id)
        {
            string sql = string.Format(@"select COUNT(*) from ProductType t
join ProductInfo p
on t.id = p.pType
where t.id = @id");
            var sdr = SqlHelp.Query(sql, new SqlParameter("id", id));
            if (sdr.Read())
            {
                if ((int)sdr[0] >= 1)
                    return true;
            }
            return false;
        }




    }
}
