using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_CRUD.Models;
using Task_CRUD.Models.ViewModels;

namespace Task_CRUD.Controllers
{
    public class TablaController : Controller
    {
        [HttpPost]
        public ActionResult Guardar(List<TablaViewModel> tablaData)
        {
            if (tablaData == null || !ModelState.IsValid)
                return View(tablaData);

            using (TaskEntities db = new TaskEntities())
            {
                // Actualizar registros existentes
                foreach (var item in tablaData.Where(x => x.Id != 0))
                {
                    var existingItem = db.TaskItem.Find(item.Id);
                    if (existingItem != null)
                    {
                        existingItem.Description = item.Description;
                        existingItem.DueDate = item.DueDate;
                        existingItem.Status = item.Status;
                    }
                }

                // Agregar nuevos registros
                foreach (var item in tablaData.Where(x => x.Id == 0 && !string.IsNullOrEmpty(x.Description)))
                {
                    db.TaskItem.Add(new TaskItem
                    {
                        Description = item.Description,
                        DueDate = item.DueDate,
                        Status = item.Status
                    });
                }

                db.SaveChanges();
            }

            return RedirectToAction("Index", "TaskItem");
        }



        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (TaskEntities db = new TaskEntities())
            {
                var item = db.TaskItem.Find(id);
                if (item != null)
                {
                    db.TaskItem.Remove(item);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "TaskItem");
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<TablaViewModel> model = new List<TablaViewModel>();

            using (TaskEntities db = new TaskEntities())
            {
                model = db.TaskItem.Select(t => new TablaViewModel
                {
                    Id = t.Id,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Status = t.Status
                }).ToList();
            }

            return View(model);
        }
    }
}
