using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BLL;

namespace WebApplication1.Controllers
{
   
    public class indexController : Controller
    {
        public static string name;
        // GET: index
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string account, string password)
        {
            name = account;
            Session["account"] = account;           
            Session["password"] = password;
           int n=  BLL.Class1.Logincheck(account, password);
            if (n == 0)
            {
                return View();

            } else if (n==1) {

                return Content("<script>location.href='/Default/index'</script>");//这边是跳转的是后台页面
            }
            else {

                return RedirectToAction("Login");//这边是跳转的是前台页面
            }
            
        }
        public ActionResult Adduser(string account, string password, string nichen, string sex, string brithday) {

            BLL.Class1.reginst(account,password,sex,brithday);
            return RedirectToAction("Index"); 
        }
        public ActionResult reginst() {

            return View();
        }
        public ActionResult musicplay(string path) {
            ViewBag.path = path;
            return View();
        }
        //文件上传的方法
        public ActionResult filecc(HttpPostedFileBase file, string singername, string musicsname)
        {
            string name1 = name;
         
            if (file != null)
            {
                if (file.ContentLength == 0)
                {
                    return RedirectToAction("Login");
                }
                else {
                    BLL.Class1.UPflie(musicsname, file.ContentLength.ToString(),singername, file.FileName.ToString(),name1);
                    file.SaveAs(Server.MapPath("/Content/musics/" + file.FileName));
                    return Content("<script>alert('添加成功');location.href='Login';</script>");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
         
        }
        public ActionResult Login(string name) {
           List<model.t_user>list=  BLL.Class1.selectuser(Session["account"].ToString(), Session["password"].ToString());
            try
            {
                Session["name"] = list[0].account;
                Session["pwd"] = list[0].password;
                Session["nichen"] = list[0].nickname;
                Session["sex"] = list[0].sex;
                Session["brithday"] = list[0].birthday;//这些是数据给取出来了，然后的话应该是做一个更新的操作
            }
            catch (Exception)
            {

                
            }
         

            ViewBag.musics = Class1.selectmusics(name);
            return View();

        }
    }
}