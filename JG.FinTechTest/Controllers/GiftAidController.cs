using Microsoft.AspNetCore.Mvc;
using JG.FinTechTest.GiftAid;
using JustGivingApi.Models;
using System;
using System.Linq;

namespace JG.FinTechTest.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GiftAidController : ControllerBase
    {
        private IGiftAidCalculator _calc = new GiftAidCalculator(20, 2, 100000); //TODO these should be in appsettings.json
        private readonly IJustGivingContext _context;

        public GiftAidController(JustGivingContext context)
        {
            _context = context;
        }

        [HttpGet("{amount}")]
        [Produces("application/json", Type = typeof(GiftAidResponse))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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

        /// <returns>A newly created JustGivingItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpPost]
        [ProducesResponseType(typeof(JustGivingItem), 201)] //item created 
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] JustGivingItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            try
            {
                item.GiftAidAmount = _calc.Calculate(item.DonationAmount);
            }
            catch (FailedValidationException e)
            {
                return BadRequest(e.Message); //Return help msg to the user.
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //Unknown error occcured - i deally all exceptions would be logged to the the application logger (not implmented here)
            }

            var response = new GiftAidDeclarationResponse();

            try
            {
                _context.AddItem(item);
                _context.SaveChanges();

                response.DeclarationId = item.Id;
                response.GiftAidAmount = item.GiftAidAmount;
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(response);
        }

        public IActionResult DefaultHelpPage()
        {
            return Ok("Help text, to make the API call use a valid amount e.g. https://localhost:44320/api/giftaid/5");
        }
    }
}
