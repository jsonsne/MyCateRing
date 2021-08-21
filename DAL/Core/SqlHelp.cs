using System.Configuration;
using System.Data.SqlClient;

namespace DAL.Core
{
    public class SqlHelp
    {
        private static string CONSTR = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

        
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqls"></param>
        /// <returns></returns>
        public static SqlDataReader Query(string sql,params SqlParameter[] sqls)
        {
            try
            {
                SqlConnection conn = new SqlConnection(CONSTR);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn);
                if (sqls != null)
                    cmd.Parameters.AddRange(sqls);
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqls"></param>
        /// <returns></returns>
        public static int Update(string sql,params SqlParameter[] sqls)
        {
            using(SqlConnection conn=new SqlConnection(CONSTR))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql,conn);
                    if (sqls != null)
                        cmd.Parameters.AddRange(sqls);
                    return cmd.ExecuteNonQuery();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// 执行sql语句并返回结果的第一行第一列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqls"></param>
        /// <returns></returns>
        public static object Scalar(string sql,params SqlParameter[] sqls)
        {
            using(SqlConnection conn=new SqlConnection(CONSTR))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql,conn);
                    if (sqls != null)
                        cmd.Parameters.AddRange(sqls);
                    return cmd.ExecuteScalar();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }



    }
}
