using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IToDoItemService
    {
        Task<ToDoItem[]> GetIncompleteItemsAsync();
        Task<bool> AddItemAsync(ToDoItem newItem);
        Task<bool> MarkDoneAsync(Guid id);
    }
}
