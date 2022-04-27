using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaForiServices.API.Models
{
    public class ToDoDBContext : DbContext
    {
        public DbSet<ToDo> ToDoList { get; set; }

        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) : base(options)
        {

        }
    }
}
