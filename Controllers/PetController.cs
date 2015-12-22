
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetClinic.Controllers
{
    public class PetController : Controller
    {
        public ActionResult View(int id)
        {
            var pet = DL.GetPet(id);
            if (pet == null) throw new Exception("no pet");//demo code 

            return View(pet);
        }

        public ActionResult AddVisit(int id)
        {
            var p = DL.GetPet(id);
            ViewBag.Pet = p;

            return View();
        }

        [HttpPost]
        public ActionResult AddVisit(int id, FormCollection collection)
        {

            var model = new Models.VISIT();

            var updated = TryUpdateModel(model   /*, includeProperties: new[] { "FirstName" }*/ );
            if (!updated || !ModelState.IsValid)
            {
                var p = DL.GetPet(id);
                ViewBag.Pet = p;
                return View(); // show errors 
            }

            //TODO: var valid = DL.Is___ Valid(model); // ask domain/business layer if OK

            model.pet = id; // smells real bad; some other way?

            DL.InsertVisit(model); // TODO: verify success

            //TODO: flash message on success 

            return RedirectToAction("View", new { id = model.pet });

        }

        // GET
        public ActionResult Add(int id /*owner id*/ )
        {
            var o = DL.GetOwner(id);
            ViewBag.Owner = o;

            // var p = new PetClinic.Models.PET { owner = id };//TODO: verify/check

            return View();
        }

        // POST 
        [HttpPost]
        public ActionResult Add(int id, FormCollection collection)
        {
            var model = new Models.PET();
            model.owner = id;

            var updated = TryUpdateModel(model   /*, includeProperties: new[] { "FirstName" }*/ );
            if (!updated || !ModelState.IsValid)
            {
                var o = DL.GetOwner(id);
                ViewBag.Owner = o;
                return View(); // show errors 
            }

            //TODO: var valid = DL.IsPetValid(model); // ask domain/business layer if OK

            DL.InsertPet(model); // TODO: verify success

            //TODO: flash message on success 

            return RedirectToAction("View", new { id = model.id }); // EF populates id

        }

    }
}
