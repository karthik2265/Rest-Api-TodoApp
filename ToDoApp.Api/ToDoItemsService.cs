using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Api.Models;

namespace ToDoApp.Api
{
    public class ToDoItemsService
    {
        public ToDoAppDbContext context;

        public ToDoItemsService(ToDoAppDbContext c)
        {
            context = c;
        }

        public List<ToDoItem> GetAllItems()
        {
            return context.ToDoItems.ToList();
        }

        public IActionResult GetItem(string id)
        {
            var item = context.ToDoItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                    return new OkObjectResult(item);
            }
            return new NotFoundResult();
        } 


        public IActionResult AddItem(ToDoItem item) {
            try
            {
                context.ToDoItems.Add(item);
                context.SaveChanges();
                return new OkObjectResult(item);
            }
            catch
            {
                return new NotFoundResult();
            }
        }

       

        public IActionResult UpdateItem(string id, ToDoItem item)
        {
            var itemToBeUpdated = context.ToDoItems.FirstOrDefault(x => x.Id == id);
            if (itemToBeUpdated != null)
            {
                itemToBeUpdated = item;
                return new OkObjectResult(item);
            }
            return new NotFoundResult();
            
        }

        public IActionResult DeleteItem(string id)
        {
            var itemToBeDeleted = context.ToDoItems.FirstOrDefault(x => x.Id == id);
            if (itemToBeDeleted != null)
            {
                itemToBeDeleted.IsDeleted = true;
                return new OkObjectResult(itemToBeDeleted);
            }
            return new NotFoundResult();
        }
        
    }
}
