using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Api.Models
{
    public class ToDoItem
    {

        public string Value { get; set; }

        public string Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
