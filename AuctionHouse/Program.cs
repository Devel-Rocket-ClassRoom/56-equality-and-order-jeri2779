using System;
using System.Collections.Generic;

// README.md를 읽고 코드를 작성하세요.

List<AuctionItem> auctionItems = new List<AuctionItem>
{
    new AuctionItem("전설의 검", 50000, 12, "무기"),
    new AuctionItem("미스릴 갑옷", 35000, 8, "방어구"),
    new AuctionItem("불꽃 반지", 28000, 15, "장신구"),
    new AuctionItem("만능 물약", 5000, 20, "소비"),
    new AuctionItem("회복 물약", 5000, 3, "소비")
};

Console.WriteLine("=== 입찰가 기준 정렬 (BidComparer) ===");
auctionItems.Sort(new BidComparer());
foreach (var item in auctionItems)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Console.WriteLine("=== 이름 기준 정렬 (BidNameComparer) ===");
auctionItems.Sort(new BidNameComparer());
foreach (var item in auctionItems)
{
    Console.WriteLine(item);
}







class AuctionItem
{
    public string Name { get; }
    public int CurrentBid { get; private set; }
    public int BidCount { get; private set; }
    public string Category { get; }

    public AuctionItem(string name, int currentBid, int bidCount, string category)
    {
        Name = name;
        CurrentBid = currentBid;
        BidCount = bidCount;
        Category = category;
    }

    public override string ToString()
    {
        return $"{Name} [{Category}] - 입찰가: {CurrentBid}골드 (입찰 {BidCount}회)";
    }
}

class BidComparer : Comparer<AuctionItem>
{
    public override int Compare(AuctionItem x, AuctionItem y)
    {
        //입찰가 내림차순
        if(x == null && y == null) return 0;
        if(x == null) return -1;
        if(y == null) return 1;
        return y.CurrentBid.CompareTo(x.CurrentBid);

         


    }

    //public override int Compare(AuctionItem x, AuctionItem y)
    //{
    //    //이름 오름차순으로 정렬
    //    if(x == null && y == null) return 0;
    //    if(x == null) return -1;
    //    if(y == null) return 1;
    //    return x.Name.CompareTo(y.Name);
    //}
}
class BidNameComparer : Comparer<AuctionItem>
{
    public override int Compare(AuctionItem x, AuctionItem y)
    {
        //이름 오름차순으로 정렬
        if(x == null && y == null) return 0;
        if(x == null) return -1;
        if(y == null) return 1;
        return y.Name.CompareTo(x.Name);
    }
}