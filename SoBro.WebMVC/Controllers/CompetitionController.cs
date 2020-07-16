using Microsoft.AspNet.Identity;
using SoBro.Models.Models;
using SoBro.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SoBro.WebMVC.Controllers
{
    [System.Web.Http.Authorize]
    public class CompetitionController : Controller
    {
        // GET: Competition
        public ActionResult Index()
        {
            var model = new CompetitionListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(CompetitionCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateCompetitionService();
            if (service.CreateCompetition(model))
            {
                TempData["SaveResult"] = "The competition was created";
                return RedirectToAction("Index");
            };
            {
                ModelState.AddModelError("", "Competition could not be created.");
                return View(model);
            }

        }
        public CompetitionService CreateCompetitionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var competitionService = new CompetitionService(userId);
            return competitionService;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCompetitionService();
            var detail = service.GetCompetitionById(id);
            var model =
                new CompetitionEdit
                {
                    CompetitionId = detail.CompetitionId,
                    Name = detail.Name,
                    City = detail.City,
                    Ranked = detail.Ranked

                };
            return View(model);
        }

        [System.Web.Mvc.ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCompetitionService();
            var model = svc.GetCompetitionById(id);
            return View(model);
        }
    }
}

