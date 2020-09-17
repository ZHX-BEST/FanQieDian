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

        public float? A相电流 { get; set; }

        public float? B相电流 { get; set; }

        public float? C相电流 { get; set; }

        public float? A相电压 { get; set; }

        public float? B相电压 { get; set; }

        public float? C相电压 { get; set; }

        public float? 用电量 { get; set; }

        public float? 变压器容量 { get; set; }

        public float? 倍率 { get; set; }

        public float? 最大电流M { get; set; }

        public float? 最小电流m { get; set; }

        //public float? 不平衡率 { get; set; }
    }
}
