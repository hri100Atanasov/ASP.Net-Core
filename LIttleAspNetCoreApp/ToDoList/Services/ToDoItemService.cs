using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly ToDoContext _context;

        public ToDoItemService(ToDoContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(ToDoItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(7);
            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<ToDoItem[]> GetIncompleteItemsAsync()
        {
            return await _context.Items.Where(i=>i.IsDone==false).ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await _context.Items.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (item==null)
            {
                return false;
            }

            item.IsDone = true;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
