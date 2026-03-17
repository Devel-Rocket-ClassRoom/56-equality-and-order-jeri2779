using System;

class Item : IEquatable<Item>
{
    public string Name;
    public int Id;

    public Item(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public bool Equals(Item other)//Equals 재정의
    {
        if (other == null) return false;
        return Name == other.Name && Id == other.Id;
    }
    
    public override bool Equals(object obj)//Equals (object obj) 오버라이드 
    {
        return Equals(obj as Item);
    }

    public override int GetHashCode()//hash code 재정의
    {
        return HashCode.Combine(Name, Id);
    }
}
