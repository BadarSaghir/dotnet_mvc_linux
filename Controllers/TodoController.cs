using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Data;

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
      var objTodoList =  _db.Todos.ToList();

        return View();
    }

}
