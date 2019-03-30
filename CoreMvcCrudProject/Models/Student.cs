using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreMvcCrudProject.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Student name must required.")]
        [DisplayName("Student Name")]
        public string StudentName { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Student code must required.")]
        [DisplayName("Student Code")]
        public string StudentRoll { get; set; }
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Student Contact")]
        public string StudentContact { get; set; }
        [Required(ErrorMessage = "Please select a Department.")]
        [DisplayName("Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department{ get; set; }
    }
}
