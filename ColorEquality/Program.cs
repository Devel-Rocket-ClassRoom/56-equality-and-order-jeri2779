using System;
using System.Collections.Generic;

// README.md를 읽고 코드를 작성하세요.

Color c1 = new Color(255, 0, 0);
Color c2 = new Color(255, 0, 0);

Console.WriteLine($"RGB(255, 0, 0) == RGB(255, 0, 0):{c1.Equals(c2)}");
Console.WriteLine($"RGB(255, 0, 0) == RGB(0, 0, 255):{c1.Equals(new Color(0, 0, 255))}");

Console.WriteLine();
Console.WriteLine("=== 유사 색상 판정 ===");
Console.WriteLine($"RGB(255, 0, 0)과 RGB(250, 5, 3)은 유사한가 (임계값 10):{c1.IsSimilar(new Color(250, 5, 3), 10)}");
Console.WriteLine($"RGB(255, 0, 0)과 RGB(200, 50, 50)은 유사한가 (임계값 10):{c1.IsSimilar(new Color(200, 50, 50), 10)}");

Console.WriteLine();
Console.WriteLine("=== HashSet 중복 제거 ===");

HashSet<Color> colorSet = new HashSet<Color>();
colorSet.Add(new Color(255, 0, 0));
colorSet.Add(new Color(0, 255, 0));
colorSet.Add(new Color(0, 0, 255));
colorSet.Add(new Color(255, 0, 0));

Console.WriteLine("팔레트에 추가된 색상:");
foreach (var color in colorSet)
{
    Console.WriteLine($"  {color}");
}
Console.WriteLine($"색상 수: {colorSet.Count}");

Console.WriteLine();
Console.WriteLine($"RGB(255, 0, 0) 포함 여부: {colorSet.Contains(new Color(255, 0, 0))}");

class Color : IEquatable<Color>
{
    public int R { get; }
    public int G { get; }
    public int B { get; }
    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }
    public bool IsSimilar(Color other, int threshold)
    {
        int rDiff = Math.Abs(R - other.R);
        int gDiff = Math.Abs(G - other.G);
        int bDiff = Math.Abs(B - other.B);
        return rDiff <= threshold && gDiff <= threshold && bDiff <= threshold;
    }
    public bool Equals(Color? other)
    {
        if (other is null) return false;
        return  R == other.R && 
                G == other.G && 
                B == other.B;
    }
    public override bool Equals(object obj)//왜 있는지 확인필요
    {
        return Equals(obj as Color);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(R, G, B);
    }
    public override string ToString()
    {
        return $"RGB({R}, {G}, {B})";
    }
}
 