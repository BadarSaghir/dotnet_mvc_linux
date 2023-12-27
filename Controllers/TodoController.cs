using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers;

// [Route("[controller]")]
public class TodoController : Controller
{
    private readonly DbApplicationContext _db;

    public TodoController(DbApplicationContext db)
    {
        _db = db;

    }
    public IActionResult Index()
    {
      IEnumerable<Todo> objTodoList =  _db.Todos;

        return View(objTodoList);
    }
     public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
      public IActionResult Create(Todo obj)
    {
        if(ModelState.IsValid){
        _db.Todos.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
        return View(obj);
    }
}
