using DAL.Core;
using MDL;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_VipCosts
    {
        //查询显示
        public List<VipCost> GetVipCosts()
        {
            List<VipCost> list = new List<VipCost>();
            string sql = "select * from VipCost";
            var sdr = SqlHelp.Query(sql);
            while (sdr.Read())
            {
                VipCost vp = new VipCost();
                vp.Id = (int)sdr["id"];
                vp.Name = sdr["name"].ToString();
                vp.ZheKou = (double)sdr["zhekou"];
                list.Add(vp);
            }

            return list;
        }

        //添加或修改
        public bool UpdateVipCost(VipCost vp)
        {
            if (vp.Id != 0)
            {
                string sql = "update vipcost set name=@name,zhekou=@zhekou where id=@id";
                return SqlHelp.Update(sql, new SqlParameter("name", vp.Name), new SqlParameter("zhekou", vp.ZheKou), new SqlParameter("id", vp.Id)) > 0;

            }
            else
            {
                string sql = "insert into vipcost(name,zhekou)values(@name, @zhekou)";
                return SqlHelp.Update(sql, new SqlParameter("name", vp.Name), new SqlParameter("zhekou", vp.ZheKou)) > 0;

            }
        }

        //删除
        public bool DeleteCost(int id)
        {
            string sql = "delete VipCost where id=@id";
            return SqlHelp.Update(sql, new SqlParameter("id", id)) > 0;
        }

        //判断是否存在引用该等级的会员
        public bool IsExistsVipUs(int id)
        {
            string sql = @"
select COUNT(*) from VipCost vc
join VipInfo vi
on vc.id=vi.vipId
where vc.id=@id
";
            var sdr = SqlHelp.Query(sql, new SqlParameter("id", id));
            if (sdr.Read())
                return (int)sdr[0] == 0;
            return false;
        }

    }
}
