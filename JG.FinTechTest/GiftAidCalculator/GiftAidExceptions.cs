using System;
namespace JG.FinTechTest.GiftAid
{
    public class FailedInitialisationException : Exception
    {
        public FailedInitialisationException()
        {
        }
        public FailedInitialisationException(string message) : base(message)
        {
        }
    }

    public class FailedValidationException : Exception
    {
        public FailedValidationException()
        {
        }
        public FailedValidationException(string message) : base(message)
        {
        }
    }
}
