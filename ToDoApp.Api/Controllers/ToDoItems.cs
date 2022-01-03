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
    public class ToDoItems : Controller
    {
        ToDoItemsService service;
        public IActionResult Index()
        {
            return View();
        }

        public ToDoItems()
        {
            service = new ToDoItemsService();
        }



        [HttpGet]
        public dynamic Get()
        {
            return service.GetAllItems();
        }

        [HttpGet]
        [Route("{id}")]
        public dynamic GetOne(int id)
        {
            return ToDoItemsService.ToDoItems.FirstOrDefault(x => x.id == id);
        }

        [HttpPost]
        public dynamic Post(ToDoItem newItem)
        {
            newItem.id = ToDoItemsService.ToDoItems.Count + 1;
            service.AddItem(newItem);
            return newItem;
        }

        [HttpDelete]
        [Route("{id}")]
        public dynamic Delete(int id)
        {
            var itemToBeDeleted = ToDoItemsService.ToDoItems.Find(x => x.id == id);
            itemToBeDeleted.isDeleted = true;
            return itemToBeDeleted;
        }

        [HttpPatch]
        [Route("{id}")]
        public dynamic Patch(int id, ToDoItem item)
        {
            var itemToBeUpdated = ToDoItemsService.ToDoItems.Find(x => x.id == id);
            itemToBeUpdated = item;
            var index = ToDoItemsService.ToDoItems.FindIndex(x => x.id == id);
            ToDoItemsService.ToDoItems[index] = itemToBeUpdated;
            itemToBeUpdated.id = index + 1;
            return itemToBeUpdated;
        }
    }
}
