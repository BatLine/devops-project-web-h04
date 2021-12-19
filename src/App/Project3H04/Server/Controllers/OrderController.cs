using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mollie.Api.Client;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models;
using Mollie.Api.Models.Payment;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment.Response;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Klant;
using Project3H04.Shared.Kunstwerken;
using Project3H04.Shared.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Project3H04.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService OrderService;
        private readonly IKlantService KlantService;

        public OrderController(IOrderService orderservice, IKlantService klantservice)
        {
            OrderService = orderservice;
            KlantService = klantservice;
        }

        [HttpGet("{id}"), ActionName("get")]
        public Task <Bestelling_DTO.Index> GetBestelling(int id)
        {
            return OrderService.GetBestelling(id);
        }

        [HttpGet("{Id}"), ActionName("exists")]
        public bool CheckIfBestellingExists(int id)
        {
            return OrderService.Bestellingexists(id);
        }

        [HttpGet("{userEmail}"), ActionName("myOrders")]
        public async Task<IEnumerable<Bestelling_DTO.Index>> GetBestellingenByUser(string userEmail)
        {
            await Task.Delay(10);
            //var authState = await AuthProvider.GetAuthenticationStateAsync();
            OrderResponse.Detail response = await OrderService.GetUserOrders(userEmail);
            return response.Bestellingen;
        }

        // creates payment and order
       
        [HttpPost, ActionName("Mollie")]
        public async Task<IActionResult> CreateOrder(Bestelling_DTO.Create bestelling)
        {
            int i = await OrderService.PostOrderAsync(bestelling);
            //int id = await OrderService.PostOrderAsync(bestelling);
            IPaymentClient paymentClient = new PaymentClient("test_5hj5GaUDpQDyrhVK4yqRfhV4PnERfn");
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = new Amount(Currency.EUR, bestelling.TotalePrijs),
                Description = $"HoopGallery test payment",
                WebhookUrl = "https://hooopgallery-acceptatie.azurewebsites.net/api/order/orderstatus",    // uses ngrok      
                RedirectUrl = $"https://hooopgallery-acceptatie.azurewebsites.net/ordersuccessful/{i}",
                Methods = new List<string>() {
                   PaymentMethod.Ideal,
                   PaymentMethod.CreditCard,
                   PaymentMethod.DirectDebit }
            };
            //int id =  OrderService.PostOrderAsync(bestelling);
            PaymentResponse paymentResponse = await paymentClient.CreatePaymentAsync(paymentRequest);
            string paymentId = paymentResponse.Id;
            await OrderService.PutOrderAsync(paymentId, i);
            Console.WriteLine(paymentRequest.RedirectUrl);
            // await OrderService.PostOrderAsync(bestelling);
            // paymentResponse.Links.Checkout;
            return Ok(paymentResponse);

            //return Redirect(paymentResponse.Links.Checkout.ToString());

        }

        [HttpPost, ActionName("MollieAndroid")]
        public async Task<IActionResult> CreateOrderAndroid(Bestelling_DTO.Create bestelling)
        {
            int i = await OrderService.PostOrderAsync(bestelling);
            //int id = await OrderService.PostOrderAsync(bestelling);
            IPaymentClient paymentClient = new PaymentClient("test_5hj5GaUDpQDyrhVK4yqRfhV4PnERfn");
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = new Amount(Currency.EUR, bestelling.TotalePrijs),
                Description = $"HoopGallery test payment",
                WebhookUrl = "https://webshop.example.org/payments/webhook/",    // uses ngrok      
                RedirectUrl = "com.hooop.android://payment-return",
                Methods = new List<string>() {
                   PaymentMethod.Ideal,
                   PaymentMethod.CreditCard,
                   PaymentMethod.DirectDebit 
                }
            };
            //int id =  OrderService.PostOrderAsync(bestelling);
            PaymentResponse paymentResponse = await paymentClient.CreatePaymentAsync(paymentRequest);
            string paymentId = paymentResponse.Id;
            await OrderService.PutOrderAsync(paymentId, i);
            Console.WriteLine(paymentRequest.RedirectUrl);
            // await OrderService.PostOrderAsync(bestelling);
            // paymentResponse.Links.Checkout;
            return Ok(paymentResponse.Links.Checkout.Href);

            //return Redirect(paymentResponse.Links.Checkout.ToString());

        }

        // This method doesn't get used anymore, Create Order creates the payment and bestelling

        // [HttpGet("{id}")]
        /*        [HttpPost, ActionName("persistOrder")]  
                public async Task<int> PostOrder(Bestelling_DTO.Create bestelling)
                {
                    // Klant_DTO k = KlantService.GetKlantById(1).Result;
                    return await OrderService.PostOrderAsync(bestelling);
                    //await Task.Delay(500);
                }*/

        //[HttpPost, ActionName("orderstatus")]
        [AllowAnonymous]
        [HttpPost, ActionName("orderstatus")]
        //public async Task PostOrderStatus()
        public async Task<IActionResult> GetOrderStatus([FromForm] string id)
        {
            // Klant_DTO k = KlantService.GetKlantById(1).Result;
            //  await OrderService.PostOrderAsync(bestelling);
            IPaymentClient paymentClient = new PaymentClient("test_5hj5GaUDpQDyrhVK4yqRfhV4PnERfn");
            PaymentResponse response =  await paymentClient.GetPaymentAsync(id);
            Console.WriteLine(response.Status);
            if(response.Status == "paid")
            {
               // await OrderService.CreateBestelling();
            }
            if(response.Status != "paid")
            {
                await OrderService.RemoveBestelling(id);
            }
            return Ok(response);
        }
    }
}
