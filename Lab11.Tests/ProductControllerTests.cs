using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using lab1.Controllers;
using WebLabsV05.Entities;
using Xunit;
using System;
using System.Text;

namespace Lab11.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            var controller = new ProductController();
            var data = TestData.GetDishesList();
            controller._autos = data;
            var comparer = Comparer<Auto>
            .GetComparer((d1, d2) => d1.AutoId.Equals(d2.AutoId));
            // act
            var result = controller.Index(2) as ViewResult; var model = result.Model as List<Auto>;
            // assert
            Assert.Equal(3, model.Count);
            Assert.Equal(data[3], model[0], comparer);
        }
        //[Theory]

        //[MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]

        //public void ControllerGetsProperPage(int page, int qty, int id)
        //{
        //    // Arrange
        //    var controller = new ProductController();
        //    controller._autos = TestData.GetDishesList();
        //    // Act
        //    var result = controller.Index(pageNo: page, group: null) as ViewResult;
        //    var model = result?.Model as List<Auto>;
        //    // Assert
        //    Assert.NotNull(model);
        //    Assert.Equal(qty, model.Count);
        //    Assert.Equal(id, model[0].AutoId);
        //}
    }
}
