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

        [Fact]
        public void Item_names_are_case_sensitive()
        {
            IList<Item> items = new List<Item> { new() { Name = "aged brie", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.NotEqual(6, items[0].Quality);
        }

        // - The Quality of an item is never more than 50
        [Fact]
        public void Aged_brie_cannot_increase_in_quality_above_50()
        {
            IList<Item> items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void Aged_brie_can_be_initialized_with_quality_higher_than_50_and_quality_is_not_lowered()
        {
            IList<Item> items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 51 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(51, items[0].Quality);
        }

        // - "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        [Fact]
        public void Sulfuras_can_not_be_initialized_with_quality_less_than_80()
        {
            IList<Item> items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 79 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(79, items[0].Quality);
        }
    }
}
