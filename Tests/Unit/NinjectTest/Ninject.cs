using Ninject.Common;

namespace Ninject
{
    [TestClass]
    public class NinjectUnit
    {
        [TestMethod]
        public void CorrectInit()
        {
            Assert.IsTrue(ServiceModule.Init(), "Dependency Injection is not correct init!");
        }

    }
}