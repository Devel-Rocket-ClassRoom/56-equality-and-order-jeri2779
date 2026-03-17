using System;
using System.Collections.Generic;

List<Item> items = new List<Item>
{
    new Item("불꽃 검", "무기", "전설"),
    new Item("얼음 검", "무기", "희귀"),
    new Item("철 갑옷", "방어구", "일반"),
    new Item("미스릴 방패", "방어구", "희귀"),
    new Item("체력물약", "소비", "일반")
};
// README.md를 읽고 코드를 작성하세요.
Console.WriteLine("=== 타입별 그룹핑 ===");
DisplayGrouping(items, new ItemTypeComparer(), "Type");
Console.WriteLine();
Console.WriteLine("=== 등급별 그룹핑 ===");
DisplayGrouping(items, new ItemGradeComparer(), "Grade");



void DisplayGrouping(List<Item> items, IEqualityComparer<Item> comparer, string mode)
{
     
    var groups = new Dictionary<Item, List<Item>>(comparer);

    foreach (var item in items)
    {
        
        if (!groups.ContainsKey(item))
        {
            groups[item] = new List<Item>();
        }
        groups[item].Add(item);
    }

    // 결과 출력
    foreach (var group in groups)
    {
         
        string header = mode == "Type" ? group.Key.Type : group.Key.Grade;
        Console.WriteLine($"[{header}]");

        foreach (var subItem in group.Value)
        {
            string detail = mode == "Type" ? subItem.Grade : subItem.Type;
            Console.WriteLine($"  - {subItem.Name} ({detail})");
        }
    }
}
class Item
{
    public string Name { get; }
    public string Type { get; }
    public string Grade { get; }

    public Item(string name, string type, string grade)
    {
        Name = name;
        Type = type;
        Grade = grade;
    }
    public override bool Equals(object? obj)
    {
        if (obj is Item other)
        {
            return Name == other.Name && Type == other.Type && Grade == other.Grade;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Type, Grade);
    }
}

class ItemTypeComparer : EqualityComparer<Item>
{
    public override bool Equals(Item? x, Item? y)
    {
        if (x == null || y == null) return false;
        return x.Type == y.Type;
    }
    public override int GetHashCode(Item obj)
    {
        return obj.Type.GetHashCode();
    }
}
class ItemGradeComparer : EqualityComparer<Item>
{
       public override bool Equals(Item? x, Item? y)
    {
        if (x == null || y == null) return false;
        return x.Grade == y.Grade;
    }
    public override int GetHashCode(Item obj)
    {
        return obj.Grade.GetHashCode();
    }

}