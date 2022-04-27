using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovaForiServices.API.Controllers;
using NovaForiServices.API.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace NovaForiServices.API.Test
{
    public class ToDoTestController
    {
        public static DbContextOptions<ToDoDBContext> dbContextOptions { get; }
        private ToDoController _toDoController;

        static ToDoTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ToDoDBContext>()
                .UseInMemoryDatabase("ToDos")
                .Options;
        }

        public ToDoTestController()
        {
            var context = new ToDoDBContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            _toDoController = new ToDoController(context);
        }

        [Fact]
        public void GetToDoListByStatus_OKResult()
        {
            var pendingData = _toDoController.GetToDoListByStatus((int)ToDoStatus.Pending);
            var completedData = _toDoController.GetToDoListByStatus((int)ToDoStatus.Completed);

            var pendingList = pendingData.Should().BeOfType<OkObjectResult>().Subject.Value.Should().BeAssignableTo<List<ToDo>>().Subject;
            var completedList = completedData.Should().BeOfType<OkObjectResult>().Subject.Value.Should().BeAssignableTo<List<ToDo>>().Subject;

            Assert.Equal(2, pendingList.Count);
            Assert.Single(completedList);
        }

        [Fact]
        public async void UpdateItemStatus_OKResult()
        {
            var data = await _toDoController.UpdateItemStatus(1);
            Assert.IsType<OkResult>(data);

            var completedData = _toDoController.GetToDoListByStatus((int)ToDoStatus.Completed);
            var completedList = completedData.Should().BeOfType<OkObjectResult>().Subject.Value.Should().BeAssignableTo<List<ToDo>>().Subject;
            Assert.Equal(2, completedList.Count);
        }

        [Fact]
        public async void UpdateItemStatus_NotFoundResult()
        {
            var data = await _toDoController.UpdateItemStatus(4);
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void AddItem_OKResult()
        {
            var data = await _toDoController.AddItem(new ToDo { ItemId = 4, ItemDescription = "Fourth Item", ItemStatus = ToDoStatus.Completed });
            Assert.IsType<OkResult>(data);

            var pendingData = _toDoController.GetToDoListByStatus((int)ToDoStatus.Pending);
            var pendingList = pendingData.Should().BeOfType<OkObjectResult>().Subject.Value.Should().BeAssignableTo<List<ToDo>>().Subject;
            Assert.Equal(3, pendingList.Count);
        }
    }
}
