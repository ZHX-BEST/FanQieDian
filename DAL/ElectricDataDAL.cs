using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Web;

using 反窃电.Models;

namespace 反窃电.DAL
{
    public class ElectricDataDAL
    {
        /// <summary>
        /// 获取某一天数据并将DataTable转为List<>
        /// </summary>
        /// <param name="classId">客户名</param>
        /// <param name="dateTime">所选时间（yy-MM-dd/ToString("d")</param>
        /// <returns></returns>
        public static List<ElectricData> getDayData(string classId, string dateTime)
        {

            string sql = $"select A相电压,B相电压,C相电压,A相电流,B相电流,C相电流,用电量,变压器容量,倍率,最大电流M,最小电流m,时间 from {classId} where CONVERT(VARCHAR(10),时间,120)=@dateTime";
            SqlParameter[] pars =
            {
                new SqlParameter("@dateTime",SqlDbType.Char)
            };
            pars[0].Value = dateTime;

            DataTable da = SqlHelper.sqlHelper.ExcuteQuery(sql, pars, CommandType.Text);
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
                ed.B相电压 = 0;
                ed.B相电流 = 0;
                ed.C相电压 = 0;
                ed.C相电流 = 0;
                //ed.户号 = "0";
                //ed.表计局号 = "0";
                //ed.类型 = 0;
                ed.倍率 = 0;
                ed.变压器容量 = 0;
                ed.用电量 = 0;
                ed.最大电流M = 0;
                ed.最小电流m = 0;
                ed.时间 = DateTime.MinValue;
                list.Add(ed);
            }
            return list;
        }

        /// <summary>
        /// 获取截止某一时间点之前的96个数据
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="dateTime">(yy-MM-dd HH:mm:ss.ff/ToString())</param>
        /// <returns></returns>
        public static List<ElectricData> getAmountData(string classId, string dateTime)
        {

            string sql = $"select top 96 A相电压,B相电压,C相电压,A相电流,B相电流,C相电流,用电量,变压器容量,倍率,最大电流M,最小电流m,时间 from {classId} where 时间<=@dateTime order by 时间 desc";
            SqlParameter[] pars =
            {
                new SqlParameter("@dateTime",SqlDbType.Char)
            };
            pars[0].Value = dateTime;

            DataTable da = SqlHelper.sqlHelper.ExcuteQuery(sql, pars, CommandType.Text);
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
                ed.B相电压 = 0;
                ed.B相电流 = 0;
                ed.C相电压 = 0;
                ed.C相电流 = 0;
                //ed.户号 = "0";
                //ed.表计局号 = "0";
                //ed.类型 = 0;
                ed.倍率 = 0;
                ed.变压器容量 = 0;
                ed.用电量 = 0;
                ed.最大电流M = 0;
                ed.最小电流m = 0;
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
            electricData.A相电压 = (float)Convert.ToDecimal(row["A相电压"]);
            electricData.B相电压 = (float)Convert.ToDecimal(row["B相电压"]);
            electricData.C相电压 = (float)Convert.ToDecimal(row["C相电压"]);
            electricData.A相电流 = (float)Convert.ToDecimal(row["A相电流"]);
            electricData.B相电流 = (float)Convert.ToDecimal(row["B相电流"]);
            electricData.C相电流 = (float)Convert.ToDecimal(row["C相电流"]);
            electricData.倍率 = (float)Convert.ToDecimal(row["倍率"]);
            electricData.变压器容量 = (float)Convert.ToDecimal(row["变压器容量"]);
            electricData.用电量 = (float)Convert.ToDecimal(row["用电量"] != DBNull.Value ? row["用电量"].ToString() : "0");            
            electricData.最大电流M = (float)Convert.ToDecimal(row["最大电流M"]);
            electricData.最小电流m = (float)Convert.ToDecimal(row["最小电流m"]);
            electricData.时间 = Convert.ToDateTime(row["时间"]);
        }

        #region 获取结果数
        //public int GetRecordCount()
        //{
        //    string sql = "select count(*) from T_News";
        //    return Convert.ToInt32(SqlHelper.ExecuteScalare(sql, CommandType.Text));
        //}
        #endregion

    }
}