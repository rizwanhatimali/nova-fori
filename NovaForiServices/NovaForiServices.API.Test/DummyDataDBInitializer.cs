using NovaForiServices.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovaForiServices.API.Test
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(ToDoDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.ToDoList.AddRange(
                    new ToDo { ItemId = 1, ItemDescription = "First Item", ItemStatus = ToDoStatus.Pending },
                    new ToDo { ItemId = 2, ItemDescription = "Second Item", ItemStatus = ToDoStatus.Completed },
                    new ToDo { ItemId = 3, ItemDescription = "Third Item", ItemStatus = ToDoStatus.Pending }
                );
            context.SaveChanges();
        }
    }
}
