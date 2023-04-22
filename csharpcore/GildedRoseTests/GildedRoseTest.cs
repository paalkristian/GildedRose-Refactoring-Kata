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
    }
}
