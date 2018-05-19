using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GridViewRemoteValidation.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult GridViewPartial() {
            return PartialView(NorthwindDataProvider.GetProducts());
        }

        public JsonResult CheckIfExists(string ProductName, string OriginalProductName) {
            return Json(!NorthwindDataProvider.CheckIfExists(ProductName, OriginalProductName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GridViewAddNewPartial(Product product) {
            if (ModelState.IsValid) {
                try {
                    NorthwindDataProvider.InsertProduct(product);
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("GridViewPartial", NorthwindDataProvider.GetProducts());
        }

        public ActionResult GridViewUpdatePartial(Product product) {
            if (ModelState.IsValid) {
                try {
                    NorthwindDataProvider.UpdateProduct(product);
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("GridViewPartial", NorthwindDataProvider.GetProducts());
        }

        public ActionResult GridViewDeletePartial(int productID) {
            try {
                NorthwindDataProvider.DeleteProduct(productID);
            }
            catch (Exception e) {
                ViewData["EditError"] = e.Message;
            }

            return PartialView("GridViewPartial", NorthwindDataProvider.GetProducts());
        }
    }
}