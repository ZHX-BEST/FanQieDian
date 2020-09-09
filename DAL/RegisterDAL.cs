using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using 反窃电.Models;

namespace 反窃电.DAL
{
    public class RegisterDAL
    {
        #region 获取用户表List<User>
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["FanQieDian"].ConnectionString;
        public static List<Register> GetUsers()
        {

            List<Register> users = new List<Register>();
            using(SqlConnection con = new SqlConnection(connStr))
            {
                string sql = "select * from register";
                using(SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();

                    using(SqlDataReader sqlDataReader = cmd.ExecuteReader()) //sqlDataReader 要求独占一个连接，且在读取时不能中断
                    {
                        if(sqlDataReader.HasRows)//判断结果集中有没有行
                        {
                            while(sqlDataReader.Read())//判断下一行中有没有数据来作为跳出循环的条件
                            {
                                Register user = new Register();
                                user.序号 = Convert.ToInt32(sqlDataReader["序号"]);
                                user.户号 = sqlDataReader["户号"].ToString();
                                user.用户名称 = sqlDataReader["用户名称"].ToString();
                                users.Add(user);
                            }
                        }
                    }
                }
                return users;
            }

        }
        #endregion
    }
}