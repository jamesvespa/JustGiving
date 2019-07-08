using JG.FinTechTest.GiftAidCalculator;
using System;

namespace JG.FinTechTest.GiftAid
{
    public class GiftAidCalculator : IGiftAidCalculator
    {
        private double taxRate;
        private double minDonation;
        private double maxDonation;
        private double giftAidAmount;

        public bool Initialised { get; private set; }

        public GiftAidCalculator()
        {
            taxRate = 0.0;
            minDonation = 0.0;
            maxDonation = 0.0;
            giftAidAmount = 0.0;

            Initialised = false;
        }

        public void Setup(double taxRate, double minDonation, double maxDonation)
        {
            this.taxRate = taxRate;
            this.minDonation = minDonation;
            this.maxDonation = maxDonation;

            Initialised = true;
        }

        public double Calculate(double donationAmount)
        {
            if (!Initialised)
            {
                throw new FailedInitialisationException("GiftAidCalculator called without Initialisation.");
            }

            if (donationAmount < minDonation ||  donationAmount > maxDonation)
            {
                string msg = string.Format("Donation amount '{0}' is out of range min='{1}' max='{2}'", donationAmount, minDonation, maxDonation);
                throw new FailedValidationException(msg);
            }

            try
            {
                giftAidAmount = donationAmount * ( taxRate / (100 - taxRate) );
            }
            catch (Exception e)
            {
                throw e;
            }

            return giftAidAmount;
        }
    }
}
