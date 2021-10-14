using ProgrammingClubM.Models;
using ProgrammingClubM.Models.ViewModels;
using ProgrammingClubM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClubM.Controllers
{
    public class MemberController : Controller
    {


        private MemberRepository repository = new MemberRepository();
        // GET: Member
        public ActionResult Index()
        {
            List<MemberModel> member = repository.GetAll();
       
            return View("Index", member);
        }


        // GET: Member/Details/5
        public ActionResult DetailsViewModel(Guid id)
        {
            MemberCodeSnippetsViewModel viewModel = repository.GetMemberCodeSnippets(id);
            return View("DetailsViewModel",viewModel);
        }

        // GET: CodeSnippet/Details/5
        public ActionResult Details(Guid id)
        {
           
            MemberModel memberModel = repository.GetById(id);
            return View("Details", memberModel);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        [Authorize(Roles = "User, Admin")]
        // POST: Member/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                MemberModel memberModel = new MemberModel();
                UpdateModel(memberModel);
                repository.InsertMember(memberModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Member/Edit/5
        public ActionResult Edit(Guid id)
        {
            MemberModel memberModel = repository.GetById(id);
            return View("Edit", memberModel);
          
        }

        [Authorize(Roles = "Admin")]
        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                MemberModel memberModel = new MemberModel();
                UpdateModel(memberModel);
                repository.UpdateMember(memberModel);
                return RedirectToAction("Index");
          
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: Member/Delete/5
        public ActionResult Delete(Guid id)
        {
            MemberModel memberModel = repository.GetById(id);

            return View("Delete", memberModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: Member/Delete/5
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
