using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidPrincipleProject.Interface;
using SolidPrincipleProject.Models;

namespace SolidPrincipleProject.Controllers
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

        [HttpGet]
        public string GetDate()
        {
            return "Data";
        }
        [HttpPost]
        public IActionResult ProcessPayment([FromBody] PaymentModel payment)
        {
            IPayment payment1 = payment.PaymentType switch
            {
                "CreditCard" => new Service.CreditCardPayment(),
                "UPI" => new Service.UpiPayment(),
                _=>null

            };
            if (payment == null)
                return BadRequest("Invalid payment type.");

            payment1.Pay(Convert.ToDecimal(payment.Amount));
            notificationService.Notify(payment.UserName, "Your payment was successful!");
            logerService.Log($"Payment of ₹{payment.Amount} processed via {payment.PaymentType}.");

            return Ok("Payment successful!");
        }
    }
}
