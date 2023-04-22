using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        
        //- At the end of each day our system lowers both values for every item
        [Fact]
        public void Item_lowers_value_at_end_of_day()
        {
            IList<Item> items = new List<Item> { new() { Name = "foo", SellIn = 5, Quality = 8 },new Item { Name = "bar", SellIn = 10, Quality = 6 }  };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(7, items[0].Quality);
            Assert.Equal(5, items[1].Quality);
        }
        
        //- Once the sell by date has passed, Quality degrades twice as fast
        [Fact]
        public void Item_lowers_value_twice_as_fast()
        {
            IList<Item> items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 8 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(6, items[0].Quality);
        }

        // - The Quality of an item is never negative
        [Fact]
        public void Item_with_quaility_0_stays_at_0()
        {
            IList<Item> items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }

        // - "Aged Brie" actually increases in Quality the older it gets
        [Fact]
        public void Aged_brie_increases_in_quality()
        {
            IList<Item> items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(6, items[0].Quality);
        }
    }
}
