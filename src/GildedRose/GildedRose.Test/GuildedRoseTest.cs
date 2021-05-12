using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using System;
using Xunit;

namespace GildedRose.Test
{
    public class GuildedRoseTest
    {
        [UseReporter]
        [Fact]
        public void UpdateQualityShould()
        {
            CombinationApprovals.VerifyAllCombinations(
                DoUpdateQuality,
                new string[] { "foo", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros" },
                new int[] {-1,0,6,11},
                new int[] {0,1,49,50}
                );

        }
        private string DoUpdateQuality(string name, int sellIn, int quality)
        {
            Item[] items = new Item[] {
                new Item
                {
                    Name = name, 
                    SellIn = sellIn, 
                    Quality = quality
                } 
            };
            var app = new GildedRose(items);
            return app.Items[0].ToString();
        }
    }
}
