using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult selectuser(string name)
        {
            ViewBag.user = BLL.Class1.selectuser(name);
            return View();
        }
        public ActionResult remove(string num,string value) {
            if (num=="1")
            {
                BLL.Class1.removeuser(value);
                return RedirectToAction("selectuser");
            }
            else
            {
                BLL.Class1.removemusics(value);
                return RedirectToAction("selectmusics");
            }
            
        }
        public ActionResult selectmusics(string name)
        {
            ViewBag.musics = BLL.Class1.selectmusics(name);
            return View();
        }
        public ActionResult Updatamusic(int name)
        {
          
            ViewBag.musics = BLL.Class1.selectmusics(name);
            return View();
        }

        [HttpPost]
        public ActionResult Updatamusic(string name,string id,string signername, string musicname)
        {
            model.t_chanson t = new model.t_chanson();
            t.name = musicname;
            t.singer = signername;
            t.id = Convert.ToInt32(id);
            BLL.Class1.UPdatamusics(t);
            return RedirectToAction("selectmusics");
        }
        
        public ActionResult Updatauser(string name)
        {
            ViewBag.user = BLL.Class1.selectuser(name);
            return View();
        }
        [HttpPost]
        public ActionResult Updatauser(string pwd,string name,string id,string bri,string sex,string acc) {
            model.t_user t = new model.t_user();
            t.account = acc;
            t.birthday = bri;
            t.nickname = name;
            t.sex = sex;
            t.state = id;
            t.password = pwd;
            BLL.Class1.UPdatauser(t);
            return RedirectToAction("selectuser");
        }
       
    }
}