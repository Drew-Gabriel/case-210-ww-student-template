using System;
using System.Collections.Generic;

namespace ProductOrderingSystem
{
    // Class to represent an Address
    public class Address
    {
        private string _streetAddress;
        private string _city;
        private string _state;
        private string _country;

        public Address(string streetAddress, string city, string state, string country)
        {
            _streetAddress = streetAddress;
            _city = city;
            _state = state;
            _country = country;
        }

        // Method to check if the address is in the USA
        public bool IsInUSA()
        {
            return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
        }

        // Method to return a full address as a string
        public string GetFullAddress()
        {
            return $"{_streetAddress}\n{_city}, {_state}\n{_country}";
        }
    }

    // Class to represent a Customer
    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        // Method to check if the customer lives in the USA
        public bool LivesInUSA()
        {
            return _address.IsInUSA();
        }

        // Method to get the customer's name
        public string GetName()
        {
            return _name;
        }

        // Method to get the address
        public Address GetAddress()
        {
            return _address;
        }
    }

    // Class to represent a Product
    public class Product
    {
        private string _name;
        private int _productId;
        private double _price;
        private int _quantity;

        public Product(string name, int productId, double price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        // Method to calculate the total cost of the product
        public double GetTotalCost()
        {
            return _price * _quantity;
        }

        // Method to get the product's details
        public string GetProductInfo()
        {
            return $"{_name} (ID: {_productId})";
        }
    }

    // Class to represent an Order
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;
        private const double DomesticShippingCost = 5.0;
        private const double InternationalShippingCost = 35.0;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        // Method to add a product to the order
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Method to calculate the total cost of the order
        public double CalculateTotalCost()
        {
            double total = 0;

            foreach (var product in _products)
            {
                total += product.GetTotalCost();
            }

            // Add shipping cost
            total += _customer.LivesInUSA() ? DomesticShippingCost : InternationalShippingCost;

            return total;
        }

        // Method to get packing label
        public string GetPackingLabel()
        {
            var packingLabel = "Packing Label:\n";
            foreach (var product in _products)
            {
                packingLabel += product.GetProductInfo() + "\n";
            }
            return packingLabel.Trim();
        }

        // Method to get shipping label
        public string GetShippingLabel()
        {
            var shippingLabel = "Shipping Label:\n";
            shippingLabel += $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
            return shippingLabel.Trim();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address address1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
            Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

            // Create customers
            Customer customer1 = new Customer("Alice Johnson", address1);
            Customer customer2 = new Customer("Bob Smith", address2);

            // Create orders
            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", 101, 999.99, 1));
            order1.AddProduct(new Product("Wireless Mouse", 102, 25.99, 2));

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Smartphone", 201, 599.99, 1));
            order2.AddProduct(new Product("Charger", 202, 19.99, 3));

            // Display order details
            DisplayOrderDetails(order1);
            DisplayOrderDetails(order2);
        }

        static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.CalculateTotalCost():0.00}");
            Console.WriteLine(); // Blank line for separation
        }
    }
}
