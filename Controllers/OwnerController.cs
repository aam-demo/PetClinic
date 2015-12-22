using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetClinic.Controllers
{
    public class OwnerController : Controller
    {
        /*

	def petclinicService

	def add() {
		if (request.method == 'GET') {
			return [ownerBean: new Owner()]
		}

		def owner = petclinicService.createOwner(params.owner_firstName, params.owner_lastName,
			params.owner_address, params.owner_city, params.owner_telephone)

		if (owner.hasErrors()) {
			return [ownerBean: owner]
		}

		redirect action: 'show', id: owner.id
	}

	def show() {
		def owner = Owner.get(params.id)
		if (!owner) {
			response.sendError 404
			return
		}

		[ownerBean: owner]
	}

	def edit() {
		def owner = Owner.get(params.id)
		if (request.method == 'GET') {
			render view: 'add', model: [ownerBean: owner]
			return
		}

		petclinicService.updateOwner(Owner.get(params.id), params.owner?.firstName, params.owner?.lastName,
			params.owner?.address, params.owner?.city, params.owner?.telephone)

		if (owner.hasErrors()) {
			render view: 'add', model: [ownerBean: owner]
			return
		}

		redirect action: 'show', id: owner.id
	}

	def find() {
		if (!request.post) {
			return
		}

		def owners = Owner.findAllByLastName(params.lastName)
		if (!owners) {
			return [message: 'owners.not.found']
		}

		if (owners.size() > 1) {
			render view: 'selection', model: [owners: owners]
		}
		else {
			redirect action: 'show', id: owners[0].id
		}
	}
    */
        /// <summary>
        /// handles both GET and POST
        /// </summary>
        public ActionResult Find()
        {
            ViewBag.Message = null; // init 
            ViewBag.Ownerlist = DL.AllOwners();

            if (this.Request.RequestType == "GET")
            {
                return View(); //Find 
                // TODO: clientside focus on sole form object (textbox)
            }
            string lastname = this.Request.Form["lastname"]; // no FindOwner bindable model 

            if (string.IsNullOrEmpty(lastname) || string.IsNullOrWhiteSpace(lastname))
            {
                ViewBag.Message = "No text entered."; // hardcoded string
                return View();
            }

            var owners = DL.FindOwnerByLastname(lastname);
            if (owners.Count == 0)
            {
                ViewBag.Message = "No owners found."; // hardcoded string; todo: extract and i18n 
                return View();
            }
            if (owners.Count == 1)
            {
                return View("Show", owners[0]); //show first/only

            }
            // more than 1 owner 
            return View("Selection", owners);

        }

        // GET: Owner/Details/5
        public ActionResult Show(int id)
        {
            var model = DL.GetOwner(id);
            if (model == null) throw new Exception("not found"); //demo code

            return View(model);
        }

        // GET: Owner/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            // explicit binding; more control 
            var model = new Models.OWNER();

            var updated = TryUpdateModel(model   /*, includeProperties: new[] { "FirstName" }*/ );
            if (!updated)
            {
                return View(); // show errors ; somehow the model is implicitly passed
            }

            // check the ModelState.IsValid boolean **********

            var valid = DL.IsOwnerValid(model); // ask domain/business layer if OK
            if (!valid) throw new Exception("invalid model"); // demo code

            DL.InsertOwner(model); // TODO: verify success

            //TODO: flash message on success 

            return RedirectToAction("Show", new { id = model.id }); // EF populates id

        }

        // GET: Owner/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Owner/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Owner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Owner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
