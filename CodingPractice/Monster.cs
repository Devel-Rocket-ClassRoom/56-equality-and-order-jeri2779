using System;

class Monster : IComparable<Monster>
{
    public string Name;
    public int Power;
    public Monster(string name, int power)
    {
        Name = name;
        Power = power;
    }
    public int CompareTo(Monster other)
    {
        if (other == null) return 1;//
        return Power.CompareTo(other.Power);
    }

    public override string ToString()
    {
        return $"{Name} (전투력: {Power})";
    }
}