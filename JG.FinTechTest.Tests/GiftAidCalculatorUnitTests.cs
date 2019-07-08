using JG.FinTechTest.GiftAid;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Call setup afer construction.
        [TestCase(20, 2, 100000, ExpectedResult = true)]
        public bool SetupCalledForGiftAidCalculatorExpectTrue(double rate, double min, double max)
        {
            GiftAidCalculator calc = new GiftAidCalculator();

            calc.Setup(rate, min, max);

            return calc.Initialised;
        }

        //Call setup after construction and then calculate.
        [TestCase(20, 2, 100000, 30,  ExpectedResult = true)]
        public bool SetupCalledForGiftAidCalculatorAndCalculateExpectTrue(double rate, double min, double max, double donation)
        {
            GiftAidCalculator calc = new GiftAidCalculator();
            try
            { 
                calc.Setup(rate, min, max);
                var result = calc.Calculate(donation);
            }
            catch(FailedInitialisationException e)
            {
                Console.WriteLine(e.Message);
            }
            return calc.Initialised;
        }

        //DO NOT Call setup after construction and then calculate - will throw an exception.
        [TestCase(20, 2, 100000, 20, ExpectedResult = false)]
        public bool SetupCalledForGiftAidCalculatorAndCalculateExpectFalse(double rate, double min, double max, double donation)
        {
            GiftAidCalculator calc = new GiftAidCalculator();

            try
            {
                var result = calc.Calculate(donation);
            }
            catch(FailedInitialisationException e)
            {
                Console.WriteLine(e.Message);
            }
            return calc.Initialised; //will return false
        }

        //calculate gift  amount 
        [TestCase(20, 2, 100000, 50, ExpectedResult = 12.5)]
        [TestCase(20, 2, 100000, 3, ExpectedResult = 0.75)] //test up to min boundry 3
        [TestCase(20, 2, 100000, 99999, ExpectedResult = 24999.75)] //test up to max boundry 99999
        public double CalculateGiftAidAmount(double rate, double min, double max, double donation)
        {
            GiftAidCalculator calc = new GiftAidCalculator();
            double amount=0.0;

            try
            {
                calc.Setup(rate, min, max);
                amount = calc.Calculate(donation);
            }
            catch (FailedInitialisationException e)
            {
                Console.WriteLine(e.Message);
            }

            return amount;
        }

        //calculate gift amount ON boundries
        [TestCase(20, 2, 100000, 2, ExpectedResult = true)] //test on min boundry 2
        [TestCase(20, 2, 100000, 100000, ExpectedResult = true)] //test on max boundry 100000
        [TestCase(20, 2, 100000, 1, ExpectedResult = false)] //test on min boundry 1 - error!
        [TestCase(20, 2, 100000, 100001, ExpectedResult = false)] //test on max boundry 100001 - error!
        public bool CalculateGiftAidAmountBoundry(double rate, double min, double max, double donation)
        {
            GiftAidCalculator calc = new GiftAidCalculator();
            double amount = 0.0;

            try
            {
                calc.Setup(rate, min, max);
                amount = calc.Calculate(donation);
            }
            catch (FailedValidationException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}