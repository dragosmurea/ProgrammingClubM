using ProgrammingClubM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgrammingClubM.Repository;

namespace ProgrammingClubM.Controllers
{
    public class AnnouncementController : Controller
    {

        private AnnouncementRepository announcementRepository = new AnnouncementRepository();
        // GET: Announcement
        public ActionResult Index()
        {
            List<AnnouncementModel> announcements = announcementRepository.GetAllAnnouncements();

            return View("Index", announcements);
        }

        // GET: Announcement/Details/5
        public ActionResult Details(Guid id)
        {
            // AnnouncementModel announcementModel = announcementRepository.Get
            AnnouncementModel announcementModel = announcementRepository.GetAnnouncementById(id);
            return View("Details", announcementModel);
        }

        // GET: Announcement/Create
        public ActionResult Create()
        {
            return View("CreateAnnouncement");
        }


        [Authorize(Roles = "User, Admin")]
        // POST: Announcement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                AnnouncementModel announcementModel = new AnnouncementModel();
                UpdateModel(announcementModel);
                announcementRepository.InsertAnnouncement(announcementModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateAnnouncement");
            }
        }

        // GET: Announcement/Edit/5
        public ActionResult Edit(Guid id)
        {
            AnnouncementModel announcementModel = announcementRepository.GetAnnouncementById(id);
            return View("EditAnnouncement", announcementModel);

        }

        [Authorize(Roles = "Admin")]

        // POST: Announcement/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                AnnouncementModel announcementModel = new AnnouncementModel();
                UpdateModel(announcementModel);
                announcementRepository.UpdateAnnouncement(announcementModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditAnnouncement");
            }
        }

        // GET: Announcement/Delete/5
        public ActionResult Delete(Guid id)
        {
             AnnouncementModel announcementModel = announcementRepository.GetAnnouncementById(id);

             return View("Delete", announcementModel);
           
        }

        [Authorize(Roles = "Admin")]
        // POST: Announcement/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                announcementRepository.DeleteAnnouncemnt(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
