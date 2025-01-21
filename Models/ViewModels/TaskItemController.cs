using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_CRUD.Models;
using Task_CRUD.Models.ViewModels;

namespace Task_CRUD.Controllers
{
    public class TaskItemController : Controller
    {
        // GET: TaskItem
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (TaskEntities db = new TaskEntities())
            {
                 lst = (from d in db.TaskItem
                          select new ListTablaViewModel
                          {
                              Id = d.Id,
                              Description = d.Description,
                              DueDate = d.DueDate,
                              Status = d.Status,
                          }).ToList();
            }



            return View(lst);
        }
    }
}