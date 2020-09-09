namespace 反窃电.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Register
    {
        public int 序号 { get; set; }
        public string 户号 { get; set; }
        public string 用户名称 { get; set; }
    }
}
