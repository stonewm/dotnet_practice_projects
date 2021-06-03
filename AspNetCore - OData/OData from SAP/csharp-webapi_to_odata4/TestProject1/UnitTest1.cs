using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiToOData4.Services;
using static System.Console;

namespace TestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1()
        {
            var sapService = new SapGLService();
            var balances = sapService.GetGlBalances("Z900", "2020", "11");

            foreach(var item in balances) {
                Write(item.GLACCOUNT);
                Write(item.ACCTEXT);
                Write(item.BALANCE);
                WriteLine();
            }
        }
    }
}
