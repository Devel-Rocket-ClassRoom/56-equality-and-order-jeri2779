using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

// README.md를 읽고 코드를 작성하세요.
Console.WriteLine("코드를 작성하세요.");
Console.WriteLine("## 1. 참조 동등성과 값 동등성");
{
    string s1 = "hello";
    string s2 = "hello";
    string s3 = new string("hello".ToCharArray());

    Console.WriteLine(s1 == s2); // True
    Console.WriteLine(s1 == s3); // True

    Console.WriteLine(object.ReferenceEquals(s1, s2)); // True
    Console.WriteLine(object.ReferenceEquals(s1, s3)); // False
}
Console.WriteLine();

Console.WriteLine("## 2. 클래스의 기본 동등성 비교");
{
    Player p1 = new Player("Hero", 10);
    Player p2 = new Player("Hero", 10);
    Player p3 = p1;

    Console.WriteLine($"p1 == p2: {p1 == p2}");
    Console.WriteLine($"p1 == p3: {p1 == p3}");
    Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
    Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
}
Console.WriteLine();

Console.WriteLine("## 3. 구조체의 기본 동등성 비교");
{
    Position pos1 = new Position(10, 20);
    Position pos2 = new Position(10, 20);
    Position pos3 = new Position(30, 40);

    Console.WriteLine($"pos1.Equals(pos2): {pos1.Equals(pos2)}");
    Console.WriteLine($"pos1.Equals(pos3): {pos1.Equals(pos3)}");
}
Console.WriteLine();

Console.WriteLine("## 4. IEquatable<T> 구현하기");
{
    Item item1 = new Item("Sword", 1);
    Item item2 = new Item("Sword", 1);
    Item item3 = new Item("Shield", 2);
    Console.WriteLine($"item1.Equals(item2): {item1.Equals(item2)}" +
        $"item1.Equals(item3): {item1.Equals(item3)}");

    HashSet<Item> inventory = new HashSet<Item>();
    inventory.Add(item1);
    Console.WriteLine($"inventory.Contains(item2): {inventory.Contains(item2)}");
}
Console.WriteLine();

Console.WriteLine("## 5. GetHashCode의 중요성");
{
    BadItem b1 = new BadItem("Potion");
    BadItem b2 = new BadItem("Potion");

    Console.WriteLine($"b1.Equals(b2): {b1.Equals(b2)}");

    Dictionary<BadItem, int> stock = new Dictionary<BadItem, int>();
    stock[b1] = 10;
    Console.WriteLine($"stock.ContainsKey(b2): {stock.ContainsKey(b2)}");
}
Console.WriteLine();

Console.WriteLine("## 6. IComparable<T> 구현하기");
{
    List<Monster> monsters = new List<Monster>
    {
        new Monster("Goblin",30),
        new Monster("Dragon",100),
        new Monster("Slime",10),
        new Monster("Orc",50)
    };

    Console.WriteLine("정렬 전:");
    foreach (Monster m in monsters)
    {
        Console.WriteLine($" {m}");
    }

    monsters.Sort(); // IComparable<Monster> 구현 덕분에 정렬 가능

    Console.WriteLine("정렬 후:");
    foreach (Monster m in monsters)
    {
        Console.WriteLine($" {m}");
    }
}
Console.WriteLine();
Console.WriteLine("## 7. 다중 기준 정렬");
{
    List<Student> students = new List<Student>
    {
        new Student("김철수", 2, 85),
        new Student("이영희", 1, 92),
        new Student("박민수", 2, 85),
        new Student("정수진", 1, 88),
        new Student("최동훈", 2, 90)
    };

    students.Sort();

    Console.WriteLine("정렬 결과:");
    foreach (Student s in students) {
        Console.WriteLine($" {s}");
    }
}
Console.WriteLine();
Console.WriteLine("## 8. EqualityComparer<T> 상속하기");
{
    Customer c1 = new Customer("Kim", "Cheolsu");
    Customer c2 = new Customer("Kim", "Cheolsu");

    Dictionary<Customer, string> dict1 = new Dictionary<Customer, string>();
    dict1[c1] = "VIP";

    Console.WriteLine($"기본 Dictionary - c2 검색: {dict1.ContainsKey(c2)}");

    Dictionary<Customer, string> dict2 = new Dictionary<Customer, string>(new CustomerComparer());
    dict2[c1] = "VIP";
    Console.WriteLine($"커스텀 Dictionary - c2 검색: {dict2.ContainsKey(c2)}");
}
Console.WriteLine();

Console.WriteLine("## 9. 대소문자 무시 문자열 비교기");
{
    Dictionary<string, int> caseInsensitive = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
    caseInsensitive["Apple"] = 100;
    caseInsensitive["BANANA"] = 200;

    Console.WriteLine($"apple 검색: {caseInsensitive["apple"]}");
    Console.WriteLine($"Banana 검색: {caseInsensitive["Banana"]}");

    //일반 딕셔너리와 비교
    Dictionary<string, int> caseSensitive = new Dictionary<string, int>();
    caseSensitive["Apple"] = 100;

    Console.WriteLine($"일반 딕셔너리에서 'apple' 존재 여부: {caseSensitive.ContainsKey("apple")}");

}
Console.WriteLine();

Console.WriteLine("## 10. Comparer<T> 상속하기");
{
    List<Quest> quests = new List<Quest>
    {
        new Quest("드래곤 처치", 1, 3000),
        new Quest("약초 수집", 3, 100),
        new Quest("마을 방어", 2, 500),
        new Quest("보물 찾기", 2, 3000)
    };

    Console.WriteLine("우선순위 기준 정렬:");
    quests.Sort(new QuestPriorityComparer());
    foreach (Quest q in quests)
    {
        Console.WriteLine($" {q}");
    }

    Console.WriteLine("보상 기준 정렬 (내립차순)");
    quests.Sort(new QuestRewardComparer());
    foreach (Quest q in quests)
    {
        Console.WriteLine($" {q}");
    }
}
Console.WriteLine();

Console.WriteLine("## 11. StringComparer 정렬");
{
    string[] frt = { "apple", "Banana", "CHERRY", "date", "Elderberry" };
    Console.WriteLine("Ordinal 정렬(대소문자 구분):");
    Array.Sort( frt, StringComparer.Ordinal );
    Console.WriteLine(string.Join(", ", frt));

    Console.WriteLine("OrdinalIgnoreCase 정렬");
    frt = new[] { "apple", "Banana", "CHERRY", "date", "Elderberry" };
    Array.Sort( frt, StringComparer.OrdinalIgnoreCase );
    Console.WriteLine(string.Join(", ", frt));

}
Console.WriteLine();

Console.WriteLine("## 12. Comparer<T>.Create() 메서드");
{
    List<Product> products = new List<Product>
    {
        new Product("키보드", 50000),
        new Product("마우스", 30000),
        new Product("모니터", 300000),
        new Product("헤드셋", 80000)

    };
    Comparer<Product> priceAcs = Comparer<Product>.Create
        (
            (x, y) => x.Price.CompareTo(y.Price)
        );

    products.Sort( priceAcs );
    Console.WriteLine("가격 오름차순 정렬:");
    foreach (Product p in products)
    {
        Console.WriteLine($" {p}");
    }

    Comparer<Product> nameDesc = Comparer<Product>.Create
    (
        (x, y) => y.Name.CompareTo(x.Name)
    );
    products.Sort( nameDesc );
    Console.WriteLine("이름 내림차순 정렬:");
    foreach (Product p in products)
    {
        Console.WriteLine($" {p}");
    }
}
Console.WriteLine();

Console.WriteLine("## 13. SortedDictionary와 비교기");
{
    SortedDictionary<int, string> scoreBoard = new SortedDictionary<int, string>(
        Comparer<int>.Create((x, y) => y.CompareTo(x))
    );

    scoreBoard[85] = "Kim";
    scoreBoard[92] = "Lee";
    scoreBoard[78] = "Park";
    scoreBoard[92] = "Choi"; // 점수 92는 Lee에서 Choi로 업데이트

    Console.WriteLine("점수 순위표");
    int rank = 1;
    foreach(KeyValuePair<int, string> entry in scoreBoard)
    {
        Console.WriteLine($"  {rank}위: {entry.Value} ({entry.Key}점)");
        rank++;
    }
}
Console.WriteLine();

Console.WriteLine("## 14. HashSet과 동등성 비교");
{
    HashSet<Equipment> equippedItems = new HashSet<Equipment>(new EquipmentTypeComparer());

    equippedItems.Add(new Equipment("불꽃 검", "무기"));
    equippedItems.Add(new Equipment("철 갑옷", "방어구"));
    equippedItems.Add(new Equipment("얼음 검", "무기"));    // 무기 타입 이미 존재
    equippedItems.Add(new Equipment("가죽 장갑", "장갑"));

    Console.WriteLine("장착된 장비:");
    foreach (Equipment e in equippedItems)
    {
        Console.WriteLine($"  {e}");
    }

}

Console.WriteLine();

Console.WriteLine("## 15. EqualityComparer<T>.Default");
{
    static bool Contains<T>(T[] array, T target)
    {
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        foreach(T item in array)
        {
            if (comparer.Equals(item, target))
            {
                return true;
            }
        }
        return false;
    }
}

class Equipment
{
    public string Name;
    public string Type;

    public Equipment(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public override string ToString()
    {
        return $"{Type}: ({Name})";
    }
}
class EquipmentTypeComparer : EqualityComparer<Equipment>
{
    public override bool Equals(Equipment x, Equipment y)
    {
        if(x == null & y == null) return false;
        if(x == null || y == null) return false;
        return x.Type == y.Type;
    }

    public override int GetHashCode(Equipment obj)
    {
        return obj?.Type?.GetHashCode() ?? 0;
    }
}
