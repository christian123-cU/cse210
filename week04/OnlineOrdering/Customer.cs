using System;

// Customer holds a name and an Address. It doesn't know HOW to check if
// it's in the USA - it just asks its own Address to figure that out.
// That felt like the main "encapsulation" lesson for this class.
class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }
}
