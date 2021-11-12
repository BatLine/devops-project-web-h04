using Microsoft.AspNetCore.Mvc;
using Mollie.Api.Client;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models;
using Mollie.Api.Models.Payment;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment.Response;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService Service;

        public OrderController(IOrderService service)
        {
            Service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Bestelling_DTO.Create bestelling)
        {
            IPaymentClient paymentClient = new PaymentClient("test_5hj5GaUDpQDyrhVK4yqRfhV4PnERfn");
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = new Amount(Currency.EUR, bestelling.TotalePrijs),
                Description = "Test payment of the example project",
                RedirectUrl = "https://localhost:5001",
                Methods = new List<string>() {
                   PaymentMethod.Ideal,
                   PaymentMethod.CreditCard,
                   PaymentMethod.DirectDebit }
            };

            PaymentResponse paymentResponse = await paymentClient.CreatePaymentAsync(paymentRequest);
            // paymentResponse.Links.Checkout;
             return Ok(paymentResponse);
            
            //return Redirect(paymentResponse.Links.Checkout.ToString());


        }
    }
}
