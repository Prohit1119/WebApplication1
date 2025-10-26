using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Interface;
using PaymentAPI.Models;
using PaymentAPI.Service;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly ILogerService logerService;
        private readonly INotificationService notificationService;

        public PaymentController(ILogerService _logerService,INotificationService _notificationService)
        {
               logerService = _logerService;
              notificationService = _notificationService;
        }
        [HttpPost]
        public IActionResult ProcessPayment([FromBody] PaymentModel request)
        {
            IPayment payment1 = request.PaymentType switch
            {
                "CreditCard" => new Service.CreditCardPayment(),
                "UPI" => new Service.UpiPayment(),
                "PayPal"=>new Service.PayPalAmount(),
                _ => null

            };
            if (request == null)
                return BadRequest("Invalid payment type.");

            payment1.Pay(Convert.ToDecimal(request.Amount));
            notificationService.Notify(request.UserName, "Your payment was successful!");
            logerService.Log($"Payment of ₹{request.Amount} processed via {request.PaymentType}.");

            return Ok("Payment successful!");
        }
    }
}
