using Microsoft.AspNetCore.Mvc;
using JG.FinTechTest.GiftAid;
using JustGivingApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace JG.FinTechTest.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GiftAidController : ControllerBase
    {
        private IGiftAidCalculator _calc  = new GiftAidCalculator(20, 2, 100000); //TODO these should be in appsettings.json
        private readonly JustGivingContext _context;

        public GiftAidController(JustGivingContext context)
        {
            _context = context;
        }

        [HttpGet("{amount}", Name = "giftaid")]
        [Produces("application/json", Type = typeof(GiftAidResponse))]
        [ProducesResponseType(200)]
        public IActionResult giftaid(double amount)
        {
            var response = new GiftAidResponse();
            response.DonationAmount = amount;

            try
            {
                response.GiftAidAmount = _calc.Calculate(amount);
            }
            catch (FailedValidationException e)
            {
               return BadRequest(e.Message); //Return help msg to the user.
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //Unknown error occcured - i deally all exceptions would be logged to the the application logger (not implmented here)
            }
            return Ok(response);
        }

        public IActionResult DefaultHelpPage()
        {
            return Ok("Help text, to make the API call use a valid amount e.g. https://localhost:44320/api/giftaid/5");
        }
    }
}
