namespace StringSorterLib.Core;

/// <summary>
/// 字符串与分割的各个部分
/// </summary>
public class StringSplitPair
{
    /// <summary>
    /// 原字符串
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// 字母、数字、特殊符号分割子串
    /// </summary>
    public string[] Parts { get; }

    public StringSplitPair(string name, string[] parts)
    {
        Name = name;
        Parts = parts;
    }
}
