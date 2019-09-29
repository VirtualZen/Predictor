using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Predictor.Test
{
    [TestClass]
    public class CoreTest
    {
        [TestMethod]
        public void CoreIsAliveTest()
        {
            Assert.IsTrue(new Predictor.Core.Core().IsAlive());
        }
    }
}
