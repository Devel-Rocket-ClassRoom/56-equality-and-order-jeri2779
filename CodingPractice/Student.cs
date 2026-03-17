using System;

class Student : IComparable<Student>
{
    public string Name;
    public int Grade;
    public int Score;

    public Student(string name, int grade, int score)
    {
        Name = name;
        Grade = grade;
        Score = score;
    }

     public int CompareTo(Student other)//CompareTo 재정의
    {
        if(other == null) return 1;
        int result = Grade.CompareTo(other.Grade);
        if(result != 0) return result;

        result = other.Score.CompareTo(Score);
        if(result != 0) return result;

        return Name.CompareTo(other.Name);
    }

    public override string ToString()
    {
        return $"{Grade}학년 {Name} ({Score}점)";
    }
}