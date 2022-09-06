namespace GildedRoses.Domain;
public class GildedRose
{
    public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
    public const string AGED_BRIE = "Aged Brie";
    public const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
    public const int MAX_QUALLITY = 50;
    public IList<Item> Items { get; }
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name != AGED_BRIE && Items[i].Name != BACKSTAGE)
            {
                if (HasAnyQuallity(Items[i]))
                {
                    if (Items[i].Name != SULFURAS)
                    {
                        DegradeQuallity(Items[i]);
                    }
                }
            }
            else
            {
                if (Items[i].Quality < MAX_QUALLITY)
                {
                    IncreaseQuallity(Items[i]);

                    if (Items[i].Name == BACKSTAGE)
                    {
                        if (Items[i].SellIn < 11)
                        {
                            if (Items[i].Quality < MAX_QUALLITY)
                            {
                                IncreaseQuallity(Items[i]);
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (Items[i].Quality < MAX_QUALLITY)
                            {
                                IncreaseQuallity(Items[i]);
                            }
                        }
                    }
                }
            }

            if (!IsLegendary(Items[i]))
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != AGED_BRIE)
                {
                    if (Items[i].Name != BACKSTAGE)
                    {
                        if (HasAnyQuallity(Items[0]))
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
                    if (Items[i].Quality < MAX_QUALLITY)
                    {
                        IncreaseQuallity(Items[i]);
                    }
                }
            }
        }

    }

    private bool IsLegendary(Item item) =>
        item.Name == SULFURAS;

    private bool HasAnyQuallity(Item item) =>
        item.Quality > 0;

    private void IncreaseQuallity(Item item) =>
        item.Quality += 1;
    private void DegradeQuallity(Item item) =>
            item.Quality -= 1;
}
