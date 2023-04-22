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
                    v.Quality = v.Quality + 1;

                    if (v.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (v.SellIn < 11)
                        {
                            if (v.Quality < 50)
                            {
                                v.Quality = v.Quality + 1;
                            }
                        }

                        if (v.SellIn < 6)
                        {
                            if (v.Quality < 50)
                            {
                                v.Quality = v.Quality + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (v.Quality > 0)
                {
                    if (v.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        v.Quality = v.Quality - 1;
                    }
                }
            }

            if (v.Name != "Sulfuras, Hand of Ragnaros")
            {
                v.SellIn = v.SellIn - 1;
            }

            if (v.SellIn < 0)
            {
                if (v.Name == "Aged Brie")
                {
                    if (v.Quality < 50)
                    {
                        v.Quality = v.Quality + 1;
                    }
                }
                else if (v.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    v.Quality = v.Quality - v.Quality;
                } 
                else 
                {
                    if (v.Quality > 0 && v.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        v.Quality = v.Quality - 1;
                    }
                }
            }
        }
    }
}
