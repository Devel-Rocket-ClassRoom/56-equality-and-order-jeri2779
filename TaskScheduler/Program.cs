using System;
using System.Collections.Generic;
using System.Threading;


// README.md를 읽고 코드를 작성하세요.
List<TodoTask> tasks = new List<TodoTask>
{
   
    new TodoTask("보고서 작성", 3, "2026-03-15", true),
    new TodoTask("이메일 확인", 1, "2026-03-10", true),
    new TodoTask("버그 수정", 3, "2026-03-10", true),
    new TodoTask("회의 준비", 2, "2026-03-12", true),
    new TodoTask("코드 리뷰", 3, "2026-03-10", true)


};
Console.WriteLine("=== 정렬 전 ===");
 
foreach (var task in tasks)
{
    Console.WriteLine(task);
}
tasks.Sort();
Console.WriteLine("=== 정렬 후 ===");
foreach(var task in tasks)
{
    Console.WriteLine(task);
}
class TodoTask : IComparable<TodoTask>
{
    public string Title { get; set; }
    public int Priority { get; set; }
    public string DueDate { get; set; }
    public bool IsComplete { get; set; }

    public TodoTask(string title, int priority, string dueDate, bool isComplete)
    {
        Title = title;
        Priority = priority;
        DueDate = dueDate;
        IsComplete = isComplete;
    }

    public int CompareTo(TodoTask other)
    {
        if (other == null) return 1;
        int result = other.Priority.CompareTo(this.Priority);

        if (result == 0)
        {
            result = this.DueDate.CompareTo(other.DueDate);
        }
        if (result == 0)
        {
            result = this.Title.CompareTo(other.Title);
        }

        return result;
    }

    public override string ToString()
    {
        return $" [우선순위 {Priority}], {Title} ({(IsComplete ? "마감" : "진행중")}, {DueDate})";
    }
}

 