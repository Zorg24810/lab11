using System;
using WebLabsV05.Entities;
using lab1.Models;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lab11.Tests
{
    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<Auto>
            .GetModel(TestData.GetDishesList(), 1, 3);
            // Assert
            Assert.Equal(2, model.TotalPages);
        }

        [Theory]
        [MemberData(memberName: nameof(TestData.Params),
            MemberType = typeof(TestData))]
        public void ListViewModelSelectsCorrectQty(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Auto>
            .GetModel(TestData.GetDishesList(), page, 3);
            // Assert
            Assert.Equal(qty, model.Count);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params),
        MemberType = typeof(TestData))]
        public void ListViewModelHasCorrectData(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Auto>
            .GetModel(TestData.GetDishesList(), page, 3);
            // Assert
            Assert.Equal(id, model[0].AutoId);
        }
    }
}

