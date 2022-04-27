using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovaForiServices.API.Models;

namespace NovaForiServices.API.Controllers
{
    [Route("api/ToDo")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDBContext _context;

        public ToDoController(ToDoDBContext context)
        {
            _context = context;
        }

        [HttpGet, Route("ListItemsByStatus/{toDoStatus}")]
        public IActionResult GetToDoListByStatus(int toDoStatus)
        {
            return Ok(_context.ToDoList.Where(obj => ((int)obj.ItemStatus == toDoStatus)).ToList());
        }

        [HttpPut, Route("UpdateStatus/{id}")]
        public async Task<IActionResult> UpdateItemStatus(int id)
        {
            var toDoListItem = await _context.ToDoList.FindAsync(id);

            if (toDoListItem == null)
            {
                return NotFound();
            }

            toDoListItem.ItemStatus = toDoListItem.ItemStatus == ToDoStatus.Pending ? ToDoStatus.Completed : ToDoStatus.Pending;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost, Route("AddItem")]
        public async Task<IActionResult> AddItem([FromBody]ToDo toDo)
        {
            int maxItemId = _context.ToDoList.Count() > 0 ? _context.ToDoList.Max(obj => obj.ItemId) : default(int);

            toDo.ItemId = maxItemId + 1;
            toDo.ItemStatus = ToDoStatus.Pending;

            _context.ToDoList.Add(toDo);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
