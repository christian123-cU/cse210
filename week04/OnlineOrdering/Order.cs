using System;
using System.Collections.Generic;

// Order ties everything together. It has one customer and a list of
// products, and it's the only class that actually needs to know about
// the shipping cost rule (USA vs not USA).
class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // Note: Order doesn't check the address itself - it just asks
        // Customer, who then asks Address. Order never touches Address
        // directly, which I think is the point of doing it this way.
        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";

        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }

        // Trim the trailing newline so it doesn't leave a blank line
        // when we print it out later.
        return label.TrimEnd('\n');
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
