namespace JG.FinTechTest.Controllers
{
    public class GiftAidResponse
    {
        public double DonationAmount { get; set; }
        public double GiftAidAmount { get; set; }
    }
    public class GiftAidDeclarationResponse
    {
        public long DeclarationId { get; set; }
        public double GiftAidAmount { get; set; }
    }
}
