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
            foreach (var v in Items)
                UpdateItem(v);
        }

        private static void UpdateItem(Item v)
        {
            switch (v.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return;
                case "Aged Brie":
                    IncreaseQuality(v);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateQualityForBackstagePasses(v);
                    break;
                default:
                    DecreaseQuality(v);
                    break;
            }

            v.SellIn--;
            if (v.SellIn >= 0)
            {
                return;
            }

            switch (v.Name)
            {
                case "Aged Brie":
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    v.Quality = 0;
                    break;
                default:
                    DecreaseQuality(v);
                    break;
            }
        }

        private static void UpdateQualityForBackstagePasses(Item v)
        {
            IncreaseQuality(v);

            if (v.SellIn < 11)
            {
                IncreaseQuality(v);
            }

            if (v.SellIn < 6)
            {
                IncreaseQuality(v);
            }
        }

        private static void IncreaseQuality(Item v)
        {
            if (v.Quality < 50)
            {
                v.Quality++;
            }
        }

        private static void DecreaseQuality(Item v)
        {
            if (v.Quality > 0)
            {
                v.Quality--;
            }
        }
    }
}