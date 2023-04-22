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
      if (v.Name == "Sulfuras, Hand of Ragnaros")
      {
        return;
      }

      if (v.Name == "Aged Brie")
      {
        IncreaseQuality(v);
      }
      else if (v.Name == "Backstage passes to a TAFKAL80ETC concert")
      {
        UpdateQualityForBackstagePasses(v);
      }
      else
      {
        DecreaseQuality(v);
      }

      v.SellIn--;
      if (v.SellIn >= 0)
      {
        return;
      }
      
      if (v.Name == "Aged Brie")
      {
        IncreaseQuality(v);
      }
      else if (v.Name == "Backstage passes to a TAFKAL80ETC concert")
      {
        v.Quality = 0;
      }
      else
      {
        DecreaseQuality(v);
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