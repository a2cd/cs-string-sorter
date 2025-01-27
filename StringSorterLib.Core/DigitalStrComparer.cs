namespace StringSorterLib.Core;

public class DigitalStrComparer : IComparer<string>
{
    private static readonly Dictionary<string, string[]> Map = new();

    public int Compare(string? s1, string? s2)
    {
        if (s1 == null && s2 == null) return 0;
        // NULLS LAST
        if (s1 == null) return 1;
        if (s2 == null) return -1;

        if (!Map.TryGetValue(s1, out var parts1))
            Map[s1] = parts1 = SplitParts(s1);

        if (!Map.TryGetValue(s2, out var parts2))
            Map[s2] = parts2 = SplitParts(s2);

        var length = Math.Min(parts1.Length, parts2.Length);
        for (var i = 0; i < length; i++)
        {
            var chType1 = ParseChType(parts1[i][0]);
            var chType2 = ParseChType(parts2[i][0]);
            // 都是数字类型，转换为数字后比较数字大小
            if (chType1 == ChType.Digit && chType1 == chType2)
            {
                var d1 = int.Parse(parts1[i]);
                var d2 = int.Parse(parts2[i]);
                if (d1 == d2) continue;
                return d1.CompareTo(d2);
            }

            // 字母或特殊字符，按字符顺序比较大小
            var f = StringComparer.Ordinal.Compare(parts1[i], parts2[i]);
            if (f != 0) return f;
        }

        return parts1.Length.CompareTo(parts2.Length); // 默认按长度排序
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
}
