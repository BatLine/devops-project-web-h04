using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Project3H04.PlaywrightTests
{
    public class ArtistsTest : PageTest
    {
        private const string ServerBaseUrl = "https://localhost:5001";
        [Test]
        public async Task Filter_On_Artist_ShouldReturn1()
        {

            await Page.GotoAsync($"{ServerBaseUrl}/artists");
            await Page.WaitForSelectorAsync("data-test-id=artists");
            await Page.FillAsync("data-test-id=artistsearch", "inara");
            await Page.Keyboard.PressAsync("Enter");
            await Page.WaitForSelectorAsync("data-test-id=artists");
            var artists = await Page.Locator("data-test-id=artists").CountAsync();
            Assert.AreEqual(1, artists);
        }
        [Test]
        public async Task HomePage_Recently_Joined_Artists_ShouldReturn4()
        {

            await Page.GotoAsync($"{ServerBaseUrl}/");
            await Page.WaitForSelectorAsync("data-test-id=recentlyjoined");
            var recentlyJoinedArtists = await Page.Locator("data-test-id=recentlyjoined").CountAsync();
            Assert.AreEqual(4, recentlyJoinedArtists);
        }
    }
}
