namespace StringSorterLib.Core;

public static class StringSorter
{
    private static readonly Comparison<StringSplitPair> Asc = (p1, p2) =>
    {
        var length = Math.Min(p1.Parts.Length, p2.Parts.Length);
        for (var i = 0; i < length; i++)
        {
            var chType1 = ParseChType(p1.Parts[i][0]);
            var chType2 = ParseChType(p2.Parts[i][0]);
            // 都是数字类型，转换为数字后比较数字大小
            if (chType1 == ChType.Digit && chType1 == chType2)
            {
                var d1 = int.Parse(p1.Parts[i]);
                var d2 = int.Parse(p2.Parts[i]);
                if (d1 == d2) continue;
                return d1.CompareTo(d2);
            }

            // 字母或特殊字符，按字符顺序比较大小
            var f = StringComparer.Ordinal.Compare(p1.Parts[i], p2.Parts[i]);
            if (f != 0) return f;
        }

        return p1.Parts.Length.CompareTo(p2.Parts.Length); // 默认按长度排序
    };

    private static readonly Comparison<StringSplitPair> Desc = (p1, p2) =>
    {
        var length = Math.Min(p1.Parts.Length, p2.Parts.Length);
        for (var i = 0; i < length; i++)
        {
            var chType1 = ParseChType(p1.Parts[i][0]);
            var chType2 = ParseChType(p2.Parts[i][0]);
            // 都是数字类型，转换为数字后比较数字大小
            if (chType1 == ChType.Digit && chType1 == chType2)
            {
                var d1 = int.Parse(p1.Parts[i]);
                var d2 = int.Parse(p2.Parts[i]);
                if (d1 == d2) continue;
                return d2.CompareTo(d1);
            }

            // 字母或特殊字符，按字符顺序比较大小
            var f = StringComparer.Ordinal.Compare(p2.Parts[i], p1.Parts[i]);
            if (f != 0) return f;
        }

        return p2.Parts.Length.CompareTo(p1.Parts.Length); // 默认按长度排序
    };

    /// <summary>
    /// 字符串排序入口
    /// </summary>
    /// <param name="list"></param>
    /// <param name="orderType"></param>
    /// <returns></returns>
    public static List<string> Sort(List<string> list, OrderType orderType = OrderType.Asc)
    {
        if (list.Count == 0) return new List<string>();

        // 1. 拆解每个string装入对象
        var pairs = new List<StringSplitPair>(list.Count);
        foreach (var str in list)
        {
            var parts = SplitParts(str);
            pairs.Add(new StringSplitPair(str, parts));
        }

        var comparison = orderType == OrderType.Desc ? Desc : Asc;

        // 2. Comparator排序对象
        pairs.Sort(comparison);
        return pairs.Select(it => it.Name).ToList();
    }

    /// <summary>
    /// 切分字符串字母与数字部分为数组
    /// 按每一个字符，切分字母、数字、特殊字符
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private static string[] SplitParts(string s)
    {
        if (s is null or "") return Array.Empty<string>();
        var list = new List<string>();
        var from = 0;
        var preChType = ParseChType(s[0]);
        for (var i = 1; i < s.Length; i++)
        {
            var chType = ParseChType(s[i]);
            if (preChType == chType) continue;
            preChType = chType;
            list.Add(s.Substring(from, i - from));
            from = i;
        }

        list.Add(s.Substring(from, s.Length - from));
        return list.ToArray();
    }

    /// <summary>
    /// 解析字符类型
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private static ChType ParseChType(char c)
    {
        return char.IsLetter(c) ? ChType.Letter : char.IsDigit(c) ? ChType.Digit : ChType.Symbol;
    }

    public static void Main()
    {

    }
}
