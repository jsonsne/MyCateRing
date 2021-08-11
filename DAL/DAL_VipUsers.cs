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
    public class DAL_VipUsers
    {

        //查询显示
        public List<ShowVipUsers> GetVipUsers(string idOrName="aaa")
        {
            List<ShowVipUsers> list = new List<ShowVipUsers>();
            string sql = @"
select vi.id,vi.name,vi.gender,vi.phone,vi.startDate,vi.endDate,vc.name as vName,vc.zheKou,vc.id as vcid from VipInfo vi
join VipCost vc
on vi.vipId=vc.id
where state=0  
";
            if (idOrName != "aaa")
            {
                if(int.TryParse(idOrName,out int id))
                    sql+= "and vi.Id=" + idOrName ;
                else
                 sql += "  and vi.name like'%" + idOrName + "%'";
            }
            var sdr = SqlHelp.Query(sql);
            while (sdr.Read())
            {
                ShowVipUsers vp = new ShowVipUsers();
                vp.Id =(int) sdr["id"];
                vp.Name = sdr["name"].ToString();
                vp.Gender = (bool)sdr["gender"]? "女" : "男";
                vp.Phone = sdr["phone"].ToString();
                vp.StartDate = sdr["startDate"].ToString();
                vp.EndDate = sdr["endDate"].ToString();
                vp.VName = sdr["vname"].ToString();
                vp.ZheKou = (double)sdr["zhekou"];
                vp.VcId = (int)sdr["vcid"];
                list.Add(vp);
             }
            return list;
        }

        //添加修改
        public bool UpdateVip(VipUsers vp)
        {
            if (vp.Id != 0)
            {
                string sql = "update VipInfo set name=@name,gender=@gender,phone=@phone,vipId=@vid,endDate=@endDate where id=@id";
                return SqlHelp.Update(sql, new SqlParameter("name", vp.Name),
                    new SqlParameter("gender", vp.Gender),
                    new SqlParameter("phone", vp.Phone),
                    new SqlParameter("vid", vp.VipId),
                    new SqlParameter("endDate", vp.EndDate),
                    new SqlParameter("id", vp.Id)
                    ) > 0;
            }
            else
            {
                string sql = "insert into VipInfo(name,gender,phone,vipid,endDate)values(@name,@gender,@phone,@vid,@endDate)";
                return SqlHelp.Update(sql, new SqlParameter("name", vp.Name),
                    new SqlParameter("gender", vp.Gender),
                    new SqlParameter("phone", vp.Phone),
                    new SqlParameter("vid", vp.VipId),
                    new SqlParameter("endDate", vp.EndDate)
                    ) > 0;
            } 
        }

        //删除
        public bool DeleteVipUser(int id)
        {
            string sql = "update VipInfo set state=1 where id=@id";
            return SqlHelp.Update(sql, new SqlParameter("id", id)) > 0;
        }

    }
}
