using DAL.Core;
using MDL;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_AdUsers
    {
        public bool IsLoginSucee(AdUsers us)
        {
            string sql = "select * from AdUsers where usCode=@code and usPwd=@pwd";
            SqlDataReader sdr = SqlHelp.Query(sql, new SqlParameter("code", us.UsCode), new SqlParameter("pwd", us.UsPwd));
            if (sdr.Read())
                return true;
            return false;

        }
    }
}
