using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Threading.Tasks;


namespace Project3H04.PlaywrightTests
{
    public class OrderTest : PageTest
    {
        private const string ServerBaseUrl = "https://localhost:5001";
        [Test]
        public async Task Navigate_To_Artworks_ShouldReturn4()
        {

            // await Page.ClickAsync("text=log in");

            await Page.GotoAsync($"{ServerBaseUrl}");
            //string UrlString = "https://dev-m-dilawar.eu.auth0.com/login?state=hKFo2SBsNUhrVUdnbkNDRDR3Wi1oaTk4MmlnU09JR1o5Z1JmeqFupWxvZ2luo3RpZNkgd3JZUXlObjRqNVktSXRlLWUxN3NaOVBmQ1pGRzN5OE2jY2lk2SA3eDV5QldsOXNXVnhDZlNYWHlSdWxWWUJIellINEdBZw&client=7x5yBWl9sWVxCfSXXyRulVYBHzYH4GAg&protocol=oauth2&redirect_uri=https%3A%2F%2Flocalhost%3A5001%2Fauthentication%2Flogin-callback&response_type=code&scope=openid%20profile&code_challenge=M2sKR_PMlMS_BDFZJnLFTZLhOqgnwqJ1QuT5dElGwwA&code_challenge_method=S256&response_mode=query";
            //await Page.GotoAsync($"{UrlString}/data-test-id="login"");
            //await Page.ClickAsync("data-test-id=login");
            await Page.RunAndWaitForNavigationAsync(async () =>
            {
                await Page.ClickAsync("data-test-id=login");
            });
            // Assert.AreEqual("https://localhost:5001/authentication/login", page.Url);
            // Click [placeholder="Enter your email"]

     //await Page.ClickAsync("[placeholder=\"Enter your email\"]");

     // Fill [placeholder="Enter your email"]
     await Page.FillAsync("[placeholder=\"Enter your email\"]", "test@gmail.com");
            // Click [placeholder="Enter your password"]
            //await Page.ClickAsync("[placeholder=\"Enter your password\"]");
            // Fill [placeholder="Enter your password"]
            await Page.FillAsync("[placeholder=\"Enter your password\"]", "test123");
            //await Page.ClickAsync("text=Log In");
            // Click text=Log In
            await Page.RunAndWaitForNavigationAsync(async () =>
            {
                await Page.ClickAsync("text=Log In");
            });
            // Click text=artworks
            await Page.WaitForNavigationAsync();
            await Page.GotoAsync($"{ServerBaseUrl}/artworks");
            // Assert.AreEqual("https://localhost:5001/artworks", page.Url);
            // Click img[alt="https://devopsh04storage.blob.core.windows.net/fotos/images/A3AT1.png"]
            await Page.ClickAsync("data-test-id=kunstwerk");
            // Assert.AreEqual("https://localhost:5001/artworks/6", page.Url);
            // Click text=Order
            await Page.WaitForSelectorAsync("h1");
            await Page.ClickAsync("data-test-id=orderbutton");

            // Click text=cart
            await Page.GotoAsync($"{ServerBaseUrl}/Orderscart");
            // Assert.AreEqual("https://localhost:5001/OrdersCart", page.Url);
            // Click text=Curtain of Desire
            await Page.WaitForSelectorAsync("h1");
            var length = await Page.Locator("data-test-id=cartitem").CountAsync();
           // var authorized = await Page.InnerTextAsync("h1");
            //Assert.AreEqual("Sorry", authorized );
            Assert.AreEqual(1, length);
        }
    }
}
