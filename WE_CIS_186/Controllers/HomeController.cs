using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using WE_CIS_186.Models;
namespace WE_CIS_186.Controllers
{
    public class HomeController : Controller
    {
        private wenevaescapeEntities db = new wenevaescapeEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Customer wes)
        {
            var littleBunny = new CustomerInf();
            if (ModelState.IsValid)
            {
                using (wenevaescapeEntities littleCat = new wenevaescapeEntities())
                {
                    //if (littleCat.CustomerInfs.Any(x => x.Name == wes.Name && x.Phone == wes.Phone && x.Email == wes.Email))
                    //{
                    //    ModelState.AddModelError("", "Khách hàng này đã có trong danh sách");
                    //    return View("Index", wes);
                    //}
                    //else
                    //{
                    littleBunny.Name = wes.Name;
                    littleBunny.Email = wes.Email;
                    littleBunny.Phone = wes.Phone;
                    littleBunny.DoB = wes.DoB;
                    littleBunny.Address = wes.Address;
                    littleBunny.PreCode = wes.PreCode;
                    littleBunny.Kangz = DateTime.Now.ToString("MM");
                    littleCat.CustomerInfs.Add(littleBunny);
                    littleCat.SaveChanges();
                    //}

                    ViewBag.SuccessMessage = "Đã thêm khách hàng";
                }
                ModelState.Clear();
            }
            return View("Index", new Customer());
        }

        public ActionResult CustomerList(string id)
        {
            var records = db.CustomerInfs.Where(x => x.Kangz.Equals(id)).FirstOrDefault();
            return View(records);
        }
        public ActionResult LoadData(string id)
        {
            List<CustomerInf> _list = new List<CustomerInf>();
            try
            {
                _list = db.CustomerInfs.ToList();
                var littleBirds = from craws in _list
                                  where craws.Kangz.Equals(id)
                                  select new[]
                                  {
                                        Convert.ToString(craws.Name),
                                        Convert.ToString(craws.DoB),
                                        Convert.ToString(craws.Phone),
                                        Convert.ToString(craws.Email),
                                        Convert.ToString(craws.Address),
                                        Convert.ToString(craws.PreCode)
                                  };
                return Json(new { aaData = littleBirds }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogers.ErrorLog(ex);
                return Json(new
                {
                    aaData = new List<string[]> { }
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}