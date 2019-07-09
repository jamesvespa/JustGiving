using JG.FinTechTest.Controllers;
using JustGivingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests
{
    public class EndPointTests
    {
        GiftAidController _controller;
        JustGivingContextFake _context;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<JustGivingContext> options = new DbContextOptions<JustGivingContext>();

            _context = new JustGivingContextFake(options); //create a Fake context so we can test the Controller
            _controller = new GiftAidController(_context);
        }

        [Test]
        public void giftaid_WhenCalled_ReturnsOkResult()
        {
            OkObjectResult okResult = (OkObjectResult) _controller.giftaid(20);

            Assert.AreEqual(okResult.StatusCode, 200);
        }

        [Test]
        public void giftaid_WhenCalled_ReturnsErrorResult()
        {
            BadRequestObjectResult badResult = (BadRequestObjectResult)_controller.giftaid(1); //outside range

            Assert.AreEqual(badResult.StatusCode, 400);
        }

        [Test]
        public void Create_WhenCalled_ReturnsOK()
        {
            JustGivingItem item = new JustGivingItem();

            item.Name = "James";
            item.DonationAmount = 20;
            item.PostCode = "SW4 6LR";

            OkObjectResult reponse = (OkObjectResult) _controller.Create(item);
            Assert.AreEqual(reponse.StatusCode, 200);
        }

        [Test]
        public void Create_WhenCalled_ReturnsOKGiftAidDeclarationResponse()
        {
            JustGivingItem item = new JustGivingItem();

            item.Name = "James";
            item.DonationAmount = 20;
            item.PostCode = "SW4 6LR";

            OkObjectResult reponse = (OkObjectResult)_controller.Create(item);
            GiftAidDeclarationResponse declaration = (GiftAidDeclarationResponse)reponse.Value;
            Assert.AreEqual(declaration.DeclarationId, 1);
            Assert.AreEqual(declaration.GiftAidAmount, 5);
        }
    }
}