using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.GiftAid
{
    interface IGiftAidCalculator
    {
        void Setup(double taxRate, double minDonation, double MaxDonation);
        double Calculate(double donationAmount);
    }
}
