using System;
using System.Collections.Generic;

namespace ProductOrderingSystem
{
    // Represents a customer's address
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }

        public Address(string street, string city, string state, string country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }

        // Determines if the address is in the USA
        public bool IsInUSA() => Country.Equals("USA", StringComparison.OrdinalIgnoreCase);

        // Returns the full address as a formatted string
        public string GetFullAddress() =>
            $"{Street}\n{City}, {State}\n{Country}";
    }

    // Represents a customer
    public class Customer
    {
        public string Name { get; }
        public Address CustomerAddress { get; }

        public Customer(string name, Address address)
        {
            Name = name;
            CustomerAddress = address;
        }

        // Determines if the customer lives in the USA
        public bool IsInUSA() => CustomerAddress.IsInUSA();
    }

    // Represents a product
    public class Product
    {
        public string Name { get; }
        public int ProductId { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public Product(string name, int productId, decimal price, int quantity)
        {
            Name = name;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        // Calculates the total cost for this product
        public decimal GetTotalCost() => Price * Quantity;
    }

    // Represents an order
    public class Order
    {
        private readonly List<Product> _products = new List<Product>();
        public Customer OrderCustomer { get; }

        public Order(Customer customer)
        {
            OrderCustomer = customer;
        }

        // Adds a product to the order
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Calculates the total price of the order
        public decimal GetTotalPrice()
        {
            decimal productsTotal = 0;
            foreach (var product in _products)
            {
                productsTotal += product.GetTotalCost();
            }

            decimal shippingCost = OrderCustomer.IsInUSA() ? 5 : 35;
            return productsTotal + shippingCost;
        }

        // Generates the packing label
        public string GetPackingLabel()
        {
            var label = "Packing Label:\n";
            foreach (var product in _products)
            {
                label += $"{product.Name} (ID: {product.ProductId})\n";
            }
            return label;
        }

        // Generates the shipping label
        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{OrderCustomer.Name}\n{OrderCustomer.CustomerAddress.GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main()
        {
            // Create customers
            var customer1 = new Customer("Alice Johnson", new Address("123 Elm St", "Springfield", "IL", "USA"));
            var customer2 = new Customer("Bob Smith", new Address("456 Oak Rd", "Toronto", "ON", "Canada"));

            // Create products
            var product1 = new Product("Laptop", 101, 999.99m, 1);
            var product2 = new Product("Wireless Mouse", 102, 25.50m, 2);
            var product3 = new Product("Keyboard", 103, 49.99m, 1);

            // Create orders
            var order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            var order2 = new Order(customer2);
            order2.AddProduct(product3);

            // Display order details
            DisplayOrderDetails(order1);
            DisplayOrderDetails(order2);
        }

        // Displays the details of an order
        static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}\n");
        }
    }
}
