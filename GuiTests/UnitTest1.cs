using System;
using GuiClient.ServerWrapper;
using Xunit;

namespace GuiTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestIcu()
        {
            var bedWrapper = new BedsWrapper();
            var result = bedWrapper.GetListOfBedsForIcu("ICU01");
            Assert.NotEmpty(result);
        }
    }
}
