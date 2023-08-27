using System;
using ZZUtils;
using NUnit.Framework;

public class DisposableTest
{

    [Test]
    public void EmptyInvoke()
    {
        var dispose = new Disposable();
        dispose.Dispose();
    }

    [Test]
    public void Add()
    {
        var str = "";
        Action act1 = () => str += "a1_";
        Action act2 = () => str += "a2_";
        var dispose = new Disposable();
        var dispose1 = new Disposable(act1);
        var dispose2 = new Disposable(act2);
        dispose.Push(dispose1, dispose2);
        dispose.Dispose();
        Assert.AreEqual(str, "a1_a2_");
        dispose.Dispose();
        Assert.AreEqual(str, "a1_a2_");
        dispose.Push(dispose1);
        dispose.Dispose();
        Assert.AreEqual(str, "a1_a2_a1_");
    }
}