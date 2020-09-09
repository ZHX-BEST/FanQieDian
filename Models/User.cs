namespace 反窃电.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int User_id { get; set; }

        [StringLength(11)]
        public string User_Tel { get; set; }

        [StringLength(100)]
        public string User_Name { get; set; }

        [StringLength(20)]
        public string User_PWD { get; set; }
    }
}
