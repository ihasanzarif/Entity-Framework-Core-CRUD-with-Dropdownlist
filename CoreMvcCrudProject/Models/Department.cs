using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreMvcCrudProject.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Department name required.")]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Department code required.")]
        [DisplayName("Department Code")]
        public string DepartmentCode { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
