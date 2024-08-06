# StringSorter

字符串排序，支持任意长度字母、数字、特殊字符排序。 

使用：  
```csharp
public static void Main()
{
    var oldList = new List<string> { "A2A", "A2A30B", "A2A3", "A1", "A2A30", "A1A" };
    var newList = Sort(oldList); // 默认升序排序
    Console.WriteLine(string.Join(", ", newList)); // A1, A1A, A2A, A2A3, A2A30, A2A30B
}
```
