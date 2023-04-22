using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateItems()
        {
            foreach (Item v in Items)
                UpdateItem(v);
        }

        private static void UpdateItem(Item v)
        {
            if (v.Name == "Aged Brie" || v.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (v.Quality < 50)
                {
                    v.Quality++;

                    if (v.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        UpdateQualityForBackstageLessThan11Days(v);
                    }
                }
            }
            else
            {
                if (v.Quality > 0 && v.Name != "Sulfuras, Hand of Ragnaros")
                {
                    v.Quality--;
                }
            }

            if (v.Name != "Sulfuras, Hand of Ragnaros")
            {
                v.SellIn--;
            }

            if (v.SellIn < 0)
            {
                if (v.Name == "Aged Brie")
                {
                    if (v.Quality < 50)
                    {
                        v.Quality++;
                    }
                }
                else if (v.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    v.Quality = 0;
                }
                else if (v.Quality > 0 && v.Name != "Sulfuras, Hand of Ragnaros")
                {
                    v.Quality--;
                }
            }
        }

        private static void UpdateQualityForBackstageLessThan11Days(Item v)
        {
            if (v.SellIn < 11)
            {
                if (v.Quality < 50)
                {
                    v.Quality++;
                }
            }

            if (v.SellIn < 6)
            {
                if (v.Quality < 50)
                {
                    v.Quality++;
                }
            }
        }
    }
}