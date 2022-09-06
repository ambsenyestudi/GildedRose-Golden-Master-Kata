namespace GildedRoses.Domain;
public class GildedRose
{
    public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
    public const string AGED_BRIE = "Aged Brie";
    public const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
    public const int MAX_QUALITY = 50;
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
                DegradeQuality(Items[i]);
            }
            else
            {

                IncreaseQuality(Items[i]);

                if (Items[i].Name == BACKSTAGE)
                {
                    if (Items[i].SellIn < 11)
                    {
                        IncreaseQuality(Items[i]);
                    }

                    if (Items[i].SellIn < 6)
                    {
                        IncreaseQuality(Items[i]);
                    }
                }

            }

            Items[i].SellIn = FigureSellIn(Items[i]);

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != AGED_BRIE)
                {
                    if (Items[i].Name != BACKSTAGE)
                    {
                        if (HasAnyQuality(Items[i]))
                        {
                            if (Items[i].Name != SULFURAS)
                            {
                                DegradeQuality(Items[i]);
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
                    IncreaseQuality(Items[i]); 
                }
            }
        }

    }
    private int FigureSellIn(Item item) =>
        IsLegendary(item)
        ? item.SellIn - 1
        : item.SellIn;

    private bool IsLegendary(Item item) =>
        item.Name == SULFURAS;

    private bool HasAnyQuality(Item item) =>
        item.Quality > 0;

    private void IncreaseQuality(Item item)
    {
        if (item.Quality < MAX_QUALITY)
        {
            item.Quality += 1;
        }
    }
    private void DegradeQuality(Item item)
    {

        if (!IsLegendary(item) && HasAnyQuality(item))
        {
            item.Quality -= 1;
        }
    }
            
}
