using System.Collections.Generic;

class QuestPriorityComparer : Comparer<Quest>
{
    public override int Compare(Quest x, Quest y)
    {
        if(x == null && y == null) return 0;
        if(x == null) return -1;
        if(y == null) return 1;
        return x.Priority.CompareTo(y.Priority); // 높은 우선순위가 먼저 오도록
    }
}
