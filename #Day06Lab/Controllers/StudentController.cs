using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

public class StudentController : Controller
{
    static List<Student> listStudents = new List<Student>();

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.AllBranches = new List<SelectListItem>
        {
            new SelectListItem { Text = "IT", Value = "1" },
            new SelectListItem { Text = "BE", Value = "2" },
            new SelectListItem { Text = "CE", Value = "3" },
            new SelectListItem { Text = "EE", Value = "4" }
        };

        ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student s)
    {
        if (ModelState.IsValid)
        {
            s.Id = listStudents.LastOrDefault()?.Id + 1 ?? 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }

        ViewBag.AllBranches = new List<SelectListItem>
        {
            new SelectListItem { Text = "IT", Value = "1" },
            new SelectListItem { Text = "BE", Value = "2" },
            new SelectListItem { Text = "CE", Value = "3" },
            new SelectListItem { Text = "EE", Value = "4" }
        };

        ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
        return View(s);
    }

    public IActionResult Index()
    {
        return View(listStudents);
    }
}
