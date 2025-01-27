namespace StringSorterLib.Core;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static void Main()
    {
        var users = new List<User> { new (2, "A10A"),new (3, "A100"), new (1, "A1AB")};
        users.ForEach(it => Console.WriteLine(it.GetHashCode()));
        var list = users.OrderBy(it => it.Name, new DigitalStrComparer()).ToList();
        list.ForEach(it => Console.WriteLine(it.GetHashCode()));
        var strs = new List<string> { "A10A", "A100", "A1AB" };
        var ordered = strs.OrderBy(it => it, new DigitalStrComparer()).ToList();
        Console.WriteLine();
    }
}



