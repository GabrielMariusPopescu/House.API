namespace HouseAPI.Repositories;

public class BidRepository
{
    private List<Bid> bids = new()
    {
        new Bid { HouseId = 1, Amount = 910000, Bidder = "Alice" },
        new Bid { HouseId = 1, Amount = 920000, Bidder = "Bob" },
        new Bid { HouseId = 2, Amount = 510000, Bidder = "Charlie" },
        new Bid { HouseId = 3, Amount = 205000, Bidder = "Diana" }
    };
    public List<Bid> GetBids(int houseId)
    {
        return bids.Where(b => b.HouseId == houseId).ToList();
    }

    public void Add(Bid bid)
    {
        bids.Add(bid);
    }
}
