using System;
using MyCarterApp;
using Xunit;

namespace MyTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var provider = new MyProvider();
            Assert.Equal("Hello from MyProvider", provider.Greet());
        }
    }
}
