using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMvcCrudProject.Models;

namespace CoreMvcCrudProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            List<Department> departments = await _context.Departments.ToListAsync();
            ViewData["Deparments"] = departments;
            return View(await _context.StudentViewModel.FromSql("SELECT * FROM StudentViewModel").ToListAsync());
        }

        public IActionResult AddDepartment(int id=0)
        {
            if (id == 0)
                return View(new Department());
            return View(_context.Departments.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDepartment([Bind("DepartmentId,DepartmentName,DepartmentCode")] Department department)
        {
            if (ModelState.IsValid)
            {
                if (department.DepartmentId == 0)
                    if (DepartmentExist(department.DepartmentCode))
                    {
                        ViewData["Message"] = "Department code is already exist.";
                        return View(department);
                    }
                    else
                    {
                        _context.Departments.Add(department);
                    }
                else
                    _context.Update(department);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<Department> departments = await _context.Departments.ToListAsync();
            ViewData["Deparments"] = departments;
            return View();
        }
        // GET: Student/Create
        public IActionResult RegisterStudent(int id=0)
        {
            List<Department> departments = _context.Departments.ToList();
            ViewData["Departments"] = departments;
            if (id == 0)
                return View(new Student());
            else
                return View(_context.Students.Find(id));
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStudent([Bind("StudentId,StudentName,StudentRoll,StudentContact,DepartmentID")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.StudentId == 0)
                    if (StudentExists(student.StudentRoll))
                    {
                        ViewData["Message"] = "Student code is already exist.";
                        return View(student);
                    }
                    else
                    {
                        _context.Add(student);
                    }
                else
                    _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }


        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteDept(int? id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string studentRoll)
        {
            return _context.Students.Any(e => e.StudentRoll == studentRoll);
        }

        private bool DepartmentExist(string departmentCode)
        {
            return _context.Departments.Any(e => e.DepartmentCode == departmentCode);
        }
    }
}
