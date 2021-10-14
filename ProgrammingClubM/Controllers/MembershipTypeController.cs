using ProgrammingClubM.Models;
using ProgrammingClubM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClubM.Controllers
{
    public class MembershipTypeController : Controller
    {
        private MembershipTypeRepository repository = new MembershipTypeRepository();
        // GET: MembershipType
        public ActionResult Index()
        {
            List<MembershipTypeModel> membershiptype = repository.GetAll();

            return View("Index", membershiptype);
        }

        // GET: MembershipType/Details/5
        public ActionResult Details(Guid id)
        {
            MembershipTypeModel membershiptypeModel = repository.GetById(id);
            return View("Details", membershiptypeModel);
        }

        // GET: MembershipType/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        [Authorize(Roles = "Admin")]
        // POST: MembershipType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                MembershipTypeModel membershiptypeModel = new MembershipTypeModel();
                UpdateModel(membershiptypeModel);
                repository.InsertMembershipType(membershiptypeModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: MembershipType/Edit/5
        public ActionResult Edit(Guid id)
        {
            MembershipTypeModel membershiptypeModel = repository.GetById(id);
            return View("Edit", membershiptypeModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: MembershipType/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                MembershipTypeModel membershiptypeModel = new MembershipTypeModel();
                UpdateModel(membershiptypeModel);
                repository.UpdateMembershipType(membershiptypeModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: MembershipType/Delete/5
        public ActionResult Delete(Guid id)
        {
            MembershipTypeModel membershiptypeModel = repository.GetById(id);

            return View("Delete", membershiptypeModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: MembershipType/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
