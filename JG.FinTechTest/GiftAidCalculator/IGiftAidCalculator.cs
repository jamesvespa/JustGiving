namespace JG.FinTechTest.GiftAid
{
    interface IGiftAidCalculator
    {
        void Setup(double taxRate, double minDonation, double MaxDonation);
        double Calculate(double donationAmount);
    }
}
