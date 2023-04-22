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
            app.UpdateItems();
            Assert.Equal(7, items[0].Quality);
            Assert.Equal(5, items[1].Quality);
        }
        
        [Fact]
        public void Item_lowers_sell_in_value_at_end_of_day()
        {
            IList<Item> items = new List<Item> { new() { Name = "foo", SellIn = 5, Quality = 8 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(4, items[0].SellIn);
        }
        
        //- Once the sell by date has passed, Quality degrades twice as fast
        [Fact]
        public void Item_lowers_value_twice_as_fast()
        {
            IList<Item> items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 8 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(6, items[0].Quality);
        }

        // - The Quality of an item is never negative
        [Fact]
        public void Item_with_quaility_0_stays_at_0()
        {
            IList<Item> items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(0, items[0].Quality);
        }

        // - "Aged Brie" actually increases in Quality the older it gets
        [Fact]
        public void Aged_brie_increases_in_quality()
        {
            IList<Item> items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(6, items[0].Quality);
        }
        
        [Fact]
        public void Aged_brie_increases_in_quality_when_sell_in_is_0()
        {
            IList<Item> items = new List<Item> { new() { Name = "Aged Brie", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(6, items[0].Quality);
        }

        [Fact]
        public void Item_names_are_case_sensitive()
        {
            IList<Item> items = new List<Item> { new() { Name = "aged brie", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.NotEqual(6, items[0].Quality);
        }

        // - The Quality of an item is never more than 50
        [Fact]
        public void Aged_brie_cannot_increase_in_quality_above_50()
        {
            IList<Item> items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void Aged_brie_can_be_initialized_with_quality_higher_than_50_and_quality_is_not_lowered()
        {
            IList<Item> items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 51 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(51, items[0].Quality);
        }

        // - "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        [Fact]
        public void Sulfuras_does_not_change_in_quality()
        {
            IList<Item> items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 25 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(25, items[0].Quality);
        }
        
        [Fact]
        public void Sulfuras_does_not_change_sell_in_value()
        {
            IList<Item> items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 25 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(10, items[0].SellIn);
        }
        
        // - "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
        // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
        // Quality drops to 0 after the concert
        [Fact]
        public void Backstage_passes_increase_in_quality_by_1_when_more_than_10_days()
        {
            IList<Item> items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 10 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void Backstage_passes_increase_in_quality_when_less_than_10_days()
        {
            IList<Item> items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 10 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(12, items[0].Quality);
        }
        
        [Fact]
        public void Backstage_passes_increase_in_quality_by_3_when_less_than_6_days()
        {
            IList<Item> items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(13, items[0].Quality);
        }

        [Fact]
        public void Backstage_passes_loses_value_on_sellinday_0()
        {
            IList<Item> items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(0, items[0].Quality);
        }


    }
}
