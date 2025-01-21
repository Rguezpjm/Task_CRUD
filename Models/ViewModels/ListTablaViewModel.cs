using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_CRUD.Models.ViewModels
{
    public class ListTablaViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status {  get; set; }

    }
}