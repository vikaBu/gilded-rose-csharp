using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        [Test]
        public void RegularItemsDecreaseTheirSellInValueByOneEachDay()
        {
            var item = new Item { Name = "Test Item", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.SellIn.Should().Be(4);
        }
        [Test] 
        public void RegularItemDoesNotDecreaseBelowZero()
        {
            var item = new Item { Name = "Test Item", Quality = 0, SellIn = 10};
            var gildedRose = new GildedRose(new List<Item> { item });

             gildedRose.UpdateQuality();

            item.Quality.Should().Be(0);
        }

                [Test] 
        public void RegularItemSellInIsZeroThenDecreaseByTwo()
        {
            var item = new Item { Name = "Test Item", Quality = 5, SellIn = 0};
            var gildedRose = new GildedRose(new List<Item> { item });

             gildedRose.UpdateQuality();

            item.Quality.Should().Be(3);
        }


        [Test]
        public void SulfurasNeverDecreaseTheirSellInValue()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.SellIn.Should().Be(5);
        }

        [Test]
        public void SulfurasNeverDecreaseTheirQuality()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            gildedRose.UpdateQuality();
            item.Quality.Should().Be(10);
        }

        [Test]
        public void AgedBrieIncreasesInTheirSellValue()
        {
            var item = new Item {Name = "Aged Brie", Quality = 20, SellIn = 20};
            var gildedRose = new GildedRose(new List<Item> {item});

            gildedRose.UpdateQuality();

            item.Quality.Should().Be(21);
        }

        [Test]
        public void AgedBrieIsExpiredIncreaseByTwo()
        {
            var item = new Item {Name ="Aged Brie", Quality = 20, SellIn = 0};
            var gildedRose = new GildedRose(new List<Item> {item});

            gildedRose.UpdateQuality();
            item.Quality.Should().Be(22);
        }


        [Test]
        public void AgedBrieQualityDoesNotGoAboveFifty()
        {
            var item = new Item {Name = "Aged Brie", Quality = 50, SellIn = 20};
            var gildedRose = new GildedRose(new List<Item> {item});

            gildedRose.UpdateQuality();
            item.Quality.Should().Be(50);
        }

        [Test]
        public void BackstagePassesIncreaseInValueMoreThanElevenDaysBefore()
        {
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 11};
            var gildedRose = new GildedRose(new List<Item> {item});

            gildedRose.UpdateQuality();
            item.Quality.Should().Be(21);
        }

        [Test]
        public void BackstagePassesIncreaseByTwoLessThanTenDaysBefore()
        {
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 10};
            var gildedRose = new GildedRose(new List<Item> {item});

            gildedRose.UpdateQuality();
            item.Quality.Should().Be(22);

        }

            [Test]
         public void BackStagePasesIncreaseByThreeLessThanFiveDays()
        {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 4};
            var gildedRose = new GildedRose(new List<Item> { item });
            gildedRose.UpdateQuality();
            item.Quality.Should().Be(23);
        }
        [Test]
         public void BackStagePasesDoesNotIncreaseOverFifty()
        {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 50, SellIn = 20};
            var gildedRose = new GildedRose(new List<Item> { item });

            gildedRose.UpdateQuality();
            item.Quality.Should().Be(50);
        }

        [Test]
         public void ShouldDropToZeroOnceSellInExpires()
        {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 5, SellIn = 0};
            var gildedRose = new GildedRose(new List<Item> { item });
            gildedRose.UpdateQuality();
            item.Quality.Should().Be(0);
        }

        // [Test]
        //  public void SellinDateIsBelowZeroThenDecreaseQualityByFour()
        // {
        // var item = new Item { Name = "Conjured Mana Cake", Quality = 5, SellIn = 0};
        //     var gildedRose = new GildedRose(new List<Item> { item });
        //     gildedRose.UpdateQuality();
        //     item.Quality.Should().Be(1);
        // }
        // [Test]
        //  public void SellinDateAboveZeroDecreaseQualityByTwo()
        // {
        // var item = new Item { Name = "Conjured Mana Cake", Quality = 5, SellIn = 2};
        //     var gildedRose = new GildedRose(new List<Item> { item });
        //     gildedRose.UpdateQuality();
        //     item.Quality.Should().Be(3);
        // }
    

    }


      

}

