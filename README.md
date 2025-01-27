# StringSorter

字符串排序，支持任意长度字母、数字、特殊字符排序。 

v2使用：  
```csharp
public static void Main()
{
    var users = new List<User> { new (2, "A10A"),new (3, "A100"), new (1, "A1AB")};
    var ordered = users.OrderBy(it => it.Name, new DigitalStrComparer()).ToList();
    
    var strs = new List<string> { "A10A", "A100", "A1AB" };
    var ordered = strs.OrderBy(it => it, new DigitalStrComparer()).ToList();
}
```

v1使用：  
```csharp
public static void Main()
{
    var oldList = new List<string> { "A2A", "A2A30B", "A2A3", "A1", "A2A30", "A1A" };
    var ordered = StringSorter.Sort(oldList); // 默认升序排序
    Console.WriteLine(string.Join(", ", ordered)); // A1, A1A, A2A, A2A3, A2A30, A2A30B
}
```

