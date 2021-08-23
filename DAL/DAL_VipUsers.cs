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
        public List<ShowVipUsers> GetVipUsers(string idOrName = "aaa")
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
                if (int.TryParse(idOrName, out int id))
                    sql += "and vi.Id=" + idOrName;
                else
                    sql += "  and vi.name like'%" + idOrName + "%'";
            }
            var sdr = SqlHelp.Query(sql);
            while (sdr.Read())
            {
                ShowVipUsers vp = new ShowVipUsers();
                vp.Id = (int)sdr["id"];
                vp.Name = sdr["name"].ToString();
                vp.Gender = (bool)sdr["gender"] ? "女" : "男";
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

        //获取会员id，名称，等级名称，折扣率
        public ShowVipUsers GetVipUsers(int id)
        {
            ShowVipUsers vip = new ShowVipUsers();
            string sql = @"
select v.id,v.name,c.name as cName,c.zheKou from VipInfo v
join VipCost c
on v.vipId=c.id
where v.id=@id and v.state=0
";
            var sdr = SqlHelp.Query(sql, new SqlParameter("id", id));
            while (sdr.Read())
            {
                vip.Id = (int)sdr["id"];
                vip.Name = sdr["name"].ToString();
                vip.VName = sdr["cName"].ToString();
                vip.ZheKou = (double)sdr["zhekou"];
            }
            return vip;
        }

        //获取会员消费信息
        public List<VipConSum> GetVipConSums(string identityStr = null)
        {
            List<VipConSum> list = new List<VipConSum>();
            string sql = @"
select v.id vid, v.name,b.id bid,b.SumPrice,vc.name vname,vc.zheKou from VipInfo v 
join CaterBill b
on v.id=b.vipId
join VipCost vc
on vc.id=v.vipId
where 1=1
";
            if (!string.IsNullOrWhiteSpace(identityStr))
            {
                if (int.TryParse(identityStr, out int num))
                {
                    sql += $" and v.id={num}";
                }
                else
                {
                    sql += $" and v.name like'%{identityStr}%'";
                }
            }

            var sdr = SqlHelp.Query(sql);
            while (sdr.Read())
            {
                VipConSum vs = new VipConSum();
                vs.Vid = (int)sdr["vid"];
                vs.Name = sdr["name"].ToString();
                vs.Bid = sdr["bid"].ToString();
                vs.SumPrice = (double)sdr["sumprice"];
                vs.ZheKou = (double)sdr["zhekou"];
                list.Add(vs);
            }
            return list;
        }
        //获取会员消费详细信息
        public List<VipDetails> GetVipDetails(string bid)
        {
            List<VipDetails> list = new List<VipDetails>();
            string sql = @"
select p.name,c.pCount,p.price from CaterBill b
join CaterDetail c
on b.id=c.biiId
join ProductInfo p
on p.id=c.pId
where b.id=@id
";
            var sdr = SqlHelp.Query(sql, new SqlParameter("id", bid));
            while (sdr.Read())
            {
                VipDetails d = new VipDetails();
                d.Pname = (string)sdr["name"];
                d.Pcount = (int)sdr["pcount"];
                d.Price = (double)sdr["price"];
                list.Add(d);
            }
            return list;
        }
    }
}
