using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ToDoViewModel
    {
        public ICollection<ToDoItem> Items { get; set; }
    }
}
