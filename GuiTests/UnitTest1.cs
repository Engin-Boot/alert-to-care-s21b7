using System;
using GuiClient.ServerWrapper;
using Xunit;

namespace GuiTests
{
    public class OccupancyTests
    {
        public OccupancyTests()
        {
            _url = "http://localhost:5000/api/";
        }
        

        [Fact]
        public void TestIcu()
        {

        }

        private static string _url;
    }
}

