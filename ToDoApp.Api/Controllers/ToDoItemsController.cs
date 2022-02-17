using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Api.Models;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemsController : Controller
    {
        ToDoItemsService service;
        public IActionResult Index()
        {
            return View();
        }

        public ToDoItemsController()
        {
            ToDoAppDbContext toDoAppDbContext = new ToDoAppDbContext();
            service = new ToDoItemsService(toDoAppDbContext);
        }



        [HttpGet]
        public dynamic Get()
        {
            return service.GetAllItems();
        }

        [HttpGet]
        [Route("{id}")]
        public dynamic GetOne(string id)
        {
            return null;
        }

        [HttpPost]
        public dynamic Post(ToDoItem newItem)
        {
            newItem.Id = DateTime.Now.ToString();
            service.AddItem(newItem);
            return newItem;
            
        }

        [HttpDelete]
        [Route("{id}")]
        public dynamic Delete(string id)
        {
            return null;
        }

        [HttpPatch]
        [Route("{id}")]
        public dynamic Patch(string id, ToDoItem item)
        {
            return null;
        }
    }
}
