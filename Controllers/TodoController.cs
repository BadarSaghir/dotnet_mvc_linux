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
        IEnumerable<Todo> objTodoList = _db.Todos;

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
        if (ModelState.IsValid)
        {
            _db.Todos.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }


    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var todoFromDb = _db.Todos.Find(id);
        if (todoFromDb == null)
        {
            return NotFound();
        }

        return View(todoFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Todo obj)
    {
        if (ModelState.IsValid)
        {
            _db.Todos.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }


    //     public IActionResult Delete(int? id)
    // {
    //     if(id==null || id==0){
    //         return NotFound();
    //     }
    //     var todoFromDb=_db.Todos.Find(id);
    //      if(todoFromDb==null){
    //         return NotFound();
    //     }

    //     return View(todoFromDb);
    // }

    // [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int? id)
    {
        var todoFromDb = _db.Todos.Find(id);
        if (todoFromDb == null)
        {
            return NotFound();
        }

        _db.Todos.Update(todoFromDb);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

}






