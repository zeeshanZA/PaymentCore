
using Domain.Payment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentApp.Models;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentApp.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentApiController : ControllerBase
    {
        private IPaymentService paymentService;

        public PaymentApiController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        // GET: api/<PaymentApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public IEnumerable<string> GetData()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        public IActionResult Post()
        {
            PaymentRequestModel paymentRequestModel = JsonConvert.DeserializeObject <PaymentRequestModel> (Request.Form["data"]);
            var validationResponse = ValidateRequest(paymentRequestModel);
            if (validationResponse == "")
            {
                var requestModel = JsonConvert.DeserializeObject<PaymentRequest>(JsonConvert.SerializeObject(paymentRequestModel));

                if (paymentService.ProcessRequest(requestModel))
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
            }
            else
            {
                return BadRequest(validationResponse);
            }
        }

        private string ValidateRequest(PaymentRequestModel paymentRequestModel)
        {
            if (paymentRequestModel.creditCardNumber.IndexOf('-') > -1)
            {
                return "Enter Credit Card Number without dash(-).";
            }
            if (paymentRequestModel.creditCardNumber.Count() != 16)
            {
                return "Credit Card Number must be in 16 figures.";
            }
            if (paymentRequestModel.expirationDate == null || paymentRequestModel.expirationDate <= DateTime.Now)
            {
                return "Expiration Date is before the current date.";
            }
            if (string.IsNullOrEmpty(paymentRequestModel.securityCode))
            {
                return "Enter Security Code.";
            }
            if (!(paymentRequestModel.amount > 0))
            {
                return "Enter Amount greater than 0.";
            }
            return "";
        }
    }
}
