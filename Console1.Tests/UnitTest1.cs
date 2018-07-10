using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Console1.Tests
{
  using System.Threading;
  using Ninject;

  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void Returns_Same_Instances_In_OneThread()
    {
      using (var kernel = new StandardKernel())
      {
        kernel.Bind<object>().ToSelf().InThreadScope();
        var instance1 = kernel.Get<object>();
        var instance2 = kernel.Get<object>();

        Assert.AreEqual(instance2, instance1);
      }
    }

    [TestMethod]
    public void Returns_Different_Instances_In_Different_Threads()
    {
      var kernel = new StandardKernel();
      kernel.Bind<object>().ToSelf().InThreadScope();
      var instance = kernel.Get<object>();

      new Thread(() =>
      {
        var instance2 = kernel.Get<object>();

        Assert.AreEqual(instance2, instance);
        kernel.Dispose();
      }).Start();
    }

    [TestMethod]
    public void Returns_Same_Instances_For_User()
    {
      using (var kernel = new StandardKernel())
      {
        kernel.Bind<object>().ToSelf().InScope(c => User.Current);
        User.Current = new User();

        var instance1 = kernel.Get<object>();
        User.Current.Name = "foo";
        var instance2 = kernel.Get<object>();
        Assert.AreEqual(instance1, instance2);
      }
    }
  }
}
