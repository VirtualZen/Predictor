using Microsoft.VisualStudio.TestTools.UnitTesting;
using Predictor.Core;

namespace Predictor.Test
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void MainIsAliveTest()
        {
            Assert.IsTrue(new Main().IsAlive());
        }
    }
}
