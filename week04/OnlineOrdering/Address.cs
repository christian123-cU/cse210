using System;

// Address just holds location info for a customer. It also knows how to
// answer "am I in the USA" which the Customer class will end up asking it.
class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Keeping this simple - just a direct string comparison. Probably not
    // bulletproof (what if someone types "United States" instead of "USA"?)
    // but that's more than this assignment is asking for I think.
    public bool IsInUSA()
    {
        return _country == "USA";
    }

    // Returns every field on its own line so it can be dropped straight
    // into a shipping label.
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}
