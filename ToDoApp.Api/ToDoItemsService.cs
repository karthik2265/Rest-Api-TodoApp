using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Api.Models;

namespace ToDoApp.Api
{
    public class ToDoItemsService
    {
        public static List<ToDoItem> ToDoItems = new List<ToDoItem> { new ToDoItem { value = "learn react", id=1 }, new ToDoItem { value = "improve everyday", id=2 } };


        public List<ToDoItem> GetAllItems()
        {
            return ToDoItems;
        }

        public ToDoItem AddItem(ToDoItem item) {
            ToDoItems.Add(item);
            return item;
        }

        public ToDoItem UpdateItem(int id, ToDoItem item)
        {
            var itemToBeUpdated = ToDoItems.FirstOrDefault(x => x.id == id);
            itemToBeUpdated = item;
            return item;
        }

        public ToDoItem DeleteItem(int id)
        {
            var itemToBeDeleted = ToDoItems.FirstOrDefault(x => x.id == id);
            itemToBeDeleted.isDeleted = true;
            return itemToBeDeleted;
        }
        
    }
}
