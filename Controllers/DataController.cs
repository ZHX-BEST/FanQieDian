using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

using 反窃电.Models;
using 反窃电.DAL;

namespace 反窃电.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            var datas = DAL.DataDAL.getdata("class1", "2019-05-24");
            return View(datas);
        }
    }
}