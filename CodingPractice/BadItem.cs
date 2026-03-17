class BadItem
{
    public string Name;
    
    public BadItem(string name)
    {
        Name = name; 
    }

    //오버라이드
    public override bool Equals(object obj)
    {
        BadItem other = obj as BadItem;
        if (other == null) return false;
        return Name == other.Name;
    }
}
