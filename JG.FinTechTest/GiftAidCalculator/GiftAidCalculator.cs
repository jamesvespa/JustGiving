using System;

namespace JG.FinTechTest.GiftAid
{
    public class GiftAidCalculator : IGiftAidCalculator
    {
        private double _taxRate;
        private double _minDonation;
        private double _maxDonation;
        private double _giftAidAmount;

        public bool Initialised { get; private set; }

        public GiftAidCalculator()
        {
            _taxRate = 0.0;
            _minDonation = 0.0;
            _maxDonation = 0.0;
            _giftAidAmount = 0.0;

            Initialised = false;
        }

        public GiftAidCalculator(double taxRate, double minDonation, double maxDonation)
        {
            Setup(taxRate, minDonation, maxDonation);
        }

        public void Setup(double taxRate, double minDonation, double maxDonation)
        {
            _taxRate = taxRate;
            _minDonation = minDonation;
            _maxDonation = maxDonation;

            Initialised = true;
        }

        public double Calculate(double donationAmount)
        {
            if (!Initialised)
            {
                throw new FailedInitialisationException("GiftAidCalculator called without Initialisation.");
            }

            if (donationAmount < _minDonation ||  donationAmount > _maxDonation)
            {
                string msg = string.Format("Donation amount '{0}' is out of range min='{1}' max='{2}'", donationAmount, _minDonation, _maxDonation);
                throw new FailedValidationException(msg);
            }

            try
            {
                _giftAidAmount = donationAmount * ( _taxRate / (100 - _taxRate) );
            }
            catch (Exception e)
            {
                throw e;
            }

            return _giftAidAmount;
        }
    }
}
