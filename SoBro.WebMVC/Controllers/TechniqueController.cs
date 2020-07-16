using Microsoft.AspNet.Identity;
using SoBro.Models.Models;
using SoBro.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SoBro.WebMVC.Controllers
{
   
        public class TechniqueController : Controller
        {
            // GET: Technique
            public ActionResult Index()
            {
                var model = new TechniqueListItem[0];
                return View(model);
            }

            public ActionResult Create()
            {
                return View();
            }

 

        [System.Web.Http.HttpPost]
        public ActionResult Create(TechniqueCreate model)
            {
                if (!ModelState.IsValid) return View(model);
                var service = CreateTechniqueService();
                if (service.CreateTechnique(model))
                {
                    TempData["SaveResult"] = "The technique was created";
                    return RedirectToAction("Index");
                };
                {
                    ModelState.AddModelError("", "Technique could not be created.");
                    return View(model);
                }

            }
            public TechniqueService CreateTechniqueService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var techniqueService = new TechniqueService(userId);
                return techniqueService;
            }

            public ActionResult Edit(int id)
            {
                var service = CreateTechniqueService();
                var detail = service.GetTechniqueById(id);
                var model =
                    new TechniqueEdit
                    {
                        TechniqueId = detail.TechniqueId,
                        Name = detail.Name,
                        Difficulty = detail.Difficulty,
                       
                    };
                return View(model);
            }

        [System.Web.Http.HttpPost]
        public ActionResult Edit(int id, TechniqueEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TechniqueId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTechniqueService();

            if (service.UpdateTechnique(model))
            {
                TempData["SaveResult"] = "Your technique was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your technique could not be updated.");
            return View(model);
        }

        

            

          

            

        }

    
}
