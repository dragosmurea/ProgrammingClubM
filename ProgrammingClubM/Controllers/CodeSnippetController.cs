using ProgrammingClubM.Models;
using ProgrammingClubM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClubM.Controllers
{
    public class CodeSnippetController : Controller
    {

        private CodeSnippetRepository codeSnippetRepository = new CodeSnippetRepository();

        // GET: CodeSnippet
        public ActionResult Index()
        {

            List<CodeSnippetModel> codeSnippets = codeSnippetRepository.GetAll();
            return View("Index", codeSnippets);
        }

        // GET: CodeSnippet/Details/5
        public ActionResult Details(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetById(id);
            return View("Details", codeSnippetModel);
        }

        // GET: CodeSnippet/Create
        public ActionResult Create()
        {


            return View("Create");
        }

        // POST: CodeSnippet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                UpdateModel(codeSnippetModel);
                codeSnippetRepository.InsertCodeSnippet(codeSnippetModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: CodeSnippet/Edit/5
        public ActionResult Edit(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetById(id);
            return View("Edit", codeSnippetModel);
        }

        // POST: CodeSnippet/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                UpdateModel(codeSnippetModel);
                codeSnippetRepository.UpdateCodeSnippet(codeSnippetModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: CodeSnippet/Delete/5
        public ActionResult Delete(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetById(id);

            return View("Delete", codeSnippetModel);
        }

        // POST: CodeSnippet/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                codeSnippetRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
