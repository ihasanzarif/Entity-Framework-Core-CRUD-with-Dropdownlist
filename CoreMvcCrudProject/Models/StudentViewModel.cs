using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvcCrudProject.Models
{
    public class StudentViewModel
    {
        [Key]
        public int StudentId { get; set; }
        [DisplayName("Student Name")]
        public string StudentName { get; set; }
        [DisplayName("Student Roll")]
        public string StudentRoll { get; set; }
        [DisplayName("Student Contact")]
        public string StudentContact { get; set; }
        public int DepartmentID { get; set; }
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        [DisplayName("Department Code")]
        public string DepartmentCode { get; set; }
    }
}
