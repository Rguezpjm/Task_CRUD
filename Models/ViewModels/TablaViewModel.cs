using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_CRUD.Models.ViewModels
{
    public class TablaViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="DueDate")]
        public DateTime DueDate { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Status")]
        public string Status { get; set; }

    }

}