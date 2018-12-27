using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<bool> AddItemAsync(ToDoItem newItem, ApplicationUser user)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.UserId = user.Id;
            newItem.DueAt = DateTimeOffset.Now.AddDays(7);
            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<ToDoItem[]> GetIncompleteItemsAsync(ApplicationUser user)
        {
            return await _context.Items.Where(i => i.IsDone == false && i.UserId == user.Id).ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser user)
        {
            var item = await _context.Items.Where(x => x.Id == id && x.UserId == user.Id).SingleOrDefaultAsync();

            if (item == null)
            {
                return false;
            }

            item.IsDone = true;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
