//Swagger to JSON and JSON to C# converted files

public class Rootobject
{
    public string swagger { get; set; }
    public Info info { get; set; }
    public string basePath { get; set; }
    public string[] schemes { get; set; }
    public Paths paths { get; set; }
    public Definitions definitions { get; set; }
}

public class Info
{
    public string title { get; set; }
    public string version { get; set; }
}

public class Paths
{
    public Giftaid giftaid { get; set; }
}

public class Giftaid
{
    public Get get { get; set; }
}

public class Get
{
    public string summary { get; set; }
    public Parameter[] parameters { get; set; } 
    public string[] produces { get; set; }
    public Responses responses { get; set; }
}

public class Responses
{
    public _200 _200 { get; set; }
}

public class _200
{
    public string description { get; set; }
    public Schema schema { get; set; }
}

public class Schema
{
    public string _ref { get; set; }
}

public class Parameter
{
    public string _in { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public bool required { get; set; }
}

//public class Definitions
//{
//    public Giftaidresponse GiftAidResponse { get; set; }
//}

//public class Giftaidresponse
//{
//    public string type { get; set; }
//    public string[] required { get; set; }
//    public Properties properties { get; set; }
//}



public class Properties
{
    public Donationamount donationAmount { get; set; }
    public Giftaidamount giftAidAmount { get; set; }
}

public class Donationamount
{
    public string type { get; set; }
}

public class Giftaidamount
{
    public string type { get; set; }
}