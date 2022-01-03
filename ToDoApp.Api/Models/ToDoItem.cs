using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Api.Models
{
    public class ToDoItem
    {
        public string value { get; set; }

        public int id { get; set; }

        public bool isDeleted { get; set; }
    }
}
