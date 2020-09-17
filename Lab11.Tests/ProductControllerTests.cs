using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using lab1.Controllers;
using WebLabsV05.Entities;
using Xunit;
using System;
using System.Text;
using Moq;
using Microsoft.AspNetCore.Http;
using WebLabsV05.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Tests
{
    public class ProductControllerTests
    {
        DbContextOptions<ApplicationDbContext> _options;
        public ProductControllerTests()
        {
            _options =
            new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "testDb")
            .Options;
        }
        
        [Theory]
        [MemberData(nameof(TestData.Params), MemberType =typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
            .Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;//заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                // создать объект класса контроллера
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };
                // Act
                var result = controller.Index(group: null, pageNo:
                page) as ViewResult;
                var model = result?.Model as List<Auto>;
                // Assert
                Assert.NotNull(model);
                Assert.Equal(qty, model.Count);
                Assert.Equal(id, model[0].AutoId);
            }
            // удалить базу данных из памяти
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }
        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
            .Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };
                var comparer = Comparer<Auto>.GetComparer((d1, d2) =>
                d1.AutoId.Equals(d2.AutoId));
                // act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<Auto>;
                // assert
                Assert.Equal(3, model.Count);
                Assert.Equal(context.Autos
                .ToArrayAsync()
                .GetAwaiter()
                .GetResult()[0], model[2], comparer);
            }
        }
    }
}
 