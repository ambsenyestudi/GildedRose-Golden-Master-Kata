namespace GildedRoses.Domain;
public class GildedRose
{
    public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
    public IList<Item> Items { get; }
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].Quality > 0)
                {
                    if (Items[i].Name != SULFURAS)
                    {
                        DegradeQuallity(Items[i]);
                    }
                }
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    IncreaseQuallity(Items[i]);

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            if (Items[i].Quality < 50)
                            {
                                IncreaseQuallity(Items[i]);
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (Items[i].Quality < 50)
                            {
                                IncreaseQuallity(Items[i]);
                            }
                        }
                    }
                }
            }

            if (Items[i].Name != SULFURAS)
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (Items[i].Name != SULFURAS)
                            {
                                DegradeQuallity(Items[i]);
                            }
                        }
                    }
                    else
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        IncreaseQuallity(Items[i]);
                    }
                }
            }
        }

    }

    private void IncreaseQuallity(Item item) =>
        item.Quality += 1;
    private void DegradeQuallity(Item item) =>
            item.Quality -= 1;
}
