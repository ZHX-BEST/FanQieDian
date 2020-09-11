using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using 反窃电.Models;

namespace 反窃电.DAL
{
    public class DataDAL
    {
        /// <summary>
        /// 获取数据并将DataTable转为List<>
        /// </summary>
        /// <param name="classId">客户名</param>
        /// <param name="dateTime">所选时间</param>
        /// <returns></returns>
        public static List<ElectricData> getdata(string classId,string dateTime)
        {

            string sql = $"select A相电压,A相电流,时间 from {classId} where CONVERT(VARCHAR(10),时间,120)=@dateTime";
            SqlParameter[] pars =
            {
                new SqlParameter("@dateTime",SqlDbType.Char)
            };
            pars[0].Value = dateTime;
            
            DataTable da = SqlHelper.sqlHelper.ExcuteQuery(sql,pars,CommandType.Text);
            List<ElectricData> list = null;
            if(da.Rows.Count > 0)
            {
                list = new List<ElectricData>();
                ElectricData electricData = null;
                foreach(DataRow row in da.Rows)
                {
                    electricData = new ElectricData();
                    LoadEntity(row, electricData);
                    list.Add(electricData);
                }

            }
            else
            {
                list = new List<ElectricData>();
                ElectricData ed = new ElectricData();
                ed.A相电压 = 0;
                ed.A相电流 = 0;
                ed.时间 = DateTime.MinValue;
                list.Add(ed);
            }
            return list;
        }

        /// <summary>
        /// 建立模型对象属性与DataRow对象属性的一一对应关系
        /// </summary>
        /// <param name="row">datatable行</param>
        /// <param name="electricData">模型对象</param>
        private static void LoadEntity(DataRow row, ElectricData electricData)
        {
            electricData.A相电压 = (double)Convert.ToSingle(row["A相电压"]);
            electricData.A相电流 = Convert.ToSingle(row["A相电流"]);
            electricData.时间 = Convert.ToDateTime(row["时间"]);
        }
        //public int GetRecordCount()
        //{
        //    string sql = "select count(*) from T_News";
        //    return Convert.ToInt32(SqlHelper.ExecuteScalare(sql, CommandType.Text));
        //}
    }
}