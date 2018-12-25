using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class FakeToDoItemService : IToDoItemService
    {
        public Task<ToDoItem[]> GetIncompleteItemsAsync()
        {
            var item1 = new ToDoItem
            {
                Title = "Learn ASP.NET Core",
                DueAt = DateTime.Now.AddDays(1)
            };

            var item2 = new ToDoItem
            {
                Title = "Build awsome apps",
                DueAt = DateTime.Now.AddDays(2)
            };

            var item3 = new ToDoItem
            {
                Title = "Build awsome apps",
                DueAt = DateTime.Now
            };

            return Task.FromResult(new[] { item1, item2, item3 });
        }
    }
}
