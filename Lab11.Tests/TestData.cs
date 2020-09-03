using System;
using System.Collections.Generic;
using System.Text;
using WebLabsV05.Entities;

namespace Lab11.Tests
{
    public class TestData
    {
        public static List<Auto> GetDishesList()
        {
            return new List<Auto>
            {

                    new Auto{ AutoId=1, AutoGroupId=1},
                    new Auto{ AutoId=2, AutoGroupId=1},
                    new Auto{ AutoId=3, AutoGroupId=1},
                    new Auto{ AutoId=4, AutoGroupId=2},
                    new Auto{ AutoId=5, AutoGroupId=2},
                    new Auto{ AutoId=6, AutoGroupId=2}
            };
        }
        
        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 3, 4 };
        }
    }
}
