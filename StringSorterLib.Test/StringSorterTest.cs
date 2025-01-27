using StringSorterLib.Core;
using Xunit;

namespace StringSorterLib.Test;

public class StringSorterTest
{
    [Fact]
    public void TestEmpty()
    {
        var list = new List<string> { "   ", "", "  ", " " };
        var actual = StringSorter.Sort(list);
        Assert.Equal(new List<string> { "", " ", "  ", "   " }, actual);
    }

    [Fact]
    public void TestOrderType()
    {
        var list = new List<string> { "B", "C", "A" };
        var ascActual = StringSorter.Sort(list);
        Assert.Equal(new List<string> { "A", "B", "C" }, ascActual);

        var descActual = StringSorter.Sort(list, OrderType.Desc);
        Assert.Equal(new List<string> { "C", "B", "A" }, descActual);
    }

    [Fact]
    public void TestDigit()
    {
        var list = new List<string> { "A10A", "A100", "A1AB" };
        var ascActual = StringSorter.Sort(list);
        Assert.Equal(new List<string> { "A1AB", "A10A", "A100" }, ascActual);

        var descActual = StringSorter.Sort(list, OrderType.Desc);
        Assert.Equal(new List<string> { "A100", "A10A", "A1AB" }, descActual);
    }

    [Fact]
    public void TestLongString()
    {
        var list = new List<string>
            { "A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A2", "A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1" };
        var ascActual = StringSorter.Sort(list);
        Assert.Equal(
            new List<string>
                { "A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1", "A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A1A2" },
            ascActual);
    }

    [Fact]
    public void TestMain()
    {
        var oldList = new List<string> { "A2A", "A2A30B", "A2A3", "A1", "A2A30", "A1A" };
        var newList = StringSorter.Sort(oldList); // 默认升序排序
        Assert.Equal(new List<string> { "A1", "A1A", "A2A", "A2A3", "A2A30", "A2A30B" }, newList);
    }


}
