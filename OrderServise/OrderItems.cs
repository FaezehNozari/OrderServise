// See https://aka.ms/new-console-template for more information

using OrderServise.CustomExteption;

public class OrderItems
{
    public int Count { get; set; }
    public string Name { get; set; }
    public OrderItems(int count , string name)
    {
        CheckCount(count);
        Count = count;  
        Name = name;
    }
    public static void CheckCount(int count)
    {
        if (count <= 0 || count > 3)
             throw new OutOfRangeCountExteption();
    }

}
