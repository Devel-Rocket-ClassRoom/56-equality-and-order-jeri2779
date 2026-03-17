class Quest
{
    public string Name { get; }
    public int Priority { get; }
    public int RewardGold { get; }
    public Quest(string name, int priority, int rewardGold)
    {
        Name = name;
        Priority = priority;
        RewardGold = rewardGold;
    }
    public override string ToString() => $"우선순위: {Priority}, {Name} (보상:{RewardGold}골드)";
}
