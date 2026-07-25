using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // --- Order 1: customer in the USA ---
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Jane Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Water Bottle", "WB100", 12.50, 2));
        order1.AddProduct(new Product("Hiking Backpack", "HB250", 45.00, 1));
        order1.AddProduct(new Product("Trail Mix", "TM010", 4.25, 3));

        // --- Order 2: customer outside the USA ---
        Address address2 = new Address("45 Baker Street", "Nairobi", "Nairobi County", "Kenya");
        Customer customer2 = new Customer("David Ochanda", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Wireless Mouse", "WM300", 18.99, 1));
        order2.AddProduct(new Product("USB-C Cable", "UC020", 6.50, 4));

        List<Order> orders = new List<Order> { order1, order2 };

        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"----- Order {orderNumber} -----");

            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}");
            Console.WriteLine();

            orderNumber++;
        }
    }
}
