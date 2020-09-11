namespace 反窃电.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class ElectricData
    {
                    //public int? 类型 { get; set; }

                    //public string 户号 { get; set; }
                    //public string 表计局号 { get; set; }

        public DateTime 时间 { get; set; }

        public double? A相电流 { get; set; }

        //public double? B相电流 { get; set; }

        //public double? C相电流 { get; set; }

        public double? A相电压 { get; set; }

        //public double? B相电压 { get; set; }

        //public double? C相电压 { get; set; }

        //public double? 用电量 { get; set; }

        //public double? 变压器容量 { get; set; }

        //public double? 倍率 { get; set; }

        //public double? 最大电流M { get; set; }

        //public double? 最小电流m { get; set; }

        //public double? 不平衡率 { get; set; }
    }
}
