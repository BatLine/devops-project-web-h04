using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Project3H04.PlaywrightTests
{
    public class ArtworkTests : PageTest
    {
        private const string ServerBaseUrl = "https://localhost:5001";
        [Test]
        public async Task Navigate_To_Artworks_ShouldReturn4()
        {

            await Page.GotoAsync($"{ServerBaseUrl}/artworks");
            await Page.WaitForSelectorAsync("data-test-id=kunstwerk");
            var amountOfKunstwerken = await Page.Locator("data-test-id=kunstwerk").CountAsync();

            Assert.AreEqual(4, amountOfKunstwerken); ;


        }

        [Test]
        public async Task Filter_On_Artist_ShouldReturn3()
        {

            await Page.GotoAsync($"{ServerBaseUrl}/artworks");
            await Page.WaitForSelectorAsync("data-test-id=kunstwerk");

            await Page.FillAsync("data-test-id=artistsearch","inara");
            await Page.Keyboard.PressAsync("Enter");


            var amountOfKunstwerken = await Page.Locator("data-test-id=kunstwerk").CountAsync();
            Assert.AreEqual(3, amountOfKunstwerken);
                
        }
    }
}