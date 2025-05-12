using System;
//Where to get the classes
using CustomerProductClasses;

namespace CustomerProductTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //The Tests, entry point
            TestProductConstructors();
            TestProductToString();
            TestProductPropertyGetters();
            TestProductPropertySetters();

            Console.WriteLine("\n---Customer Tests---");
            TestCustomerConstructors();
            TestCustomerToString();
            TestCustomerPropertyGetters();
            TestCustomerPropertySetters();
        }

        static void TestProductConstructors()
        {
            //Verifys the constructors
            Product p1 = new Product();
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing Product constructors");
            Console.WriteLine("Default constructor.  Expecting default values. 0, , , 0.00, 0 " + p1.ToString());
            Console.WriteLine("Overloaded constructor.  Expecting 1, T100, This is a test product, 100.00, 10 " + p2.ToString());
            Console.WriteLine();
        }

        static void TestProductToString()
        {
            //Test toString
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing Product ToString");
            Console.WriteLine("Expecting 1, T100, This is a test product, 100.00, 10 " + p1.ToString());
            Console.WriteLine("Expecting 1, T100, This is a test product, 100.00, 10 " + p1);
            Console.WriteLine();
        }

        static void TestProductPropertyGetters()
        {
            //Test getters
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing Product getters");
            Console.WriteLine("Id.  Expecting 1. " + p1.Id);
            Console.WriteLine("Code.  Expecting T100. " + p1.Code);
            Console.WriteLine("Description.  Expecting This is a test product. " + p1.Description);
            Console.WriteLine("Price.  Expecting 100.00. " + p1.UnitPrice);
            Console.WriteLine("Quantity.  Expecting 10. " + p1.QuantityOnHand);
            Console.WriteLine();
        }

        static void TestProductPropertySetters()
        {
            //Test setters
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing Product setters");
            p1.Id = 2;
            p1.Code = "T000";
            p1.Description = "First product";
            p1.UnitPrice = 200M;
            p1.QuantityOnHand = 20;
            Console.WriteLine("Expecting 2, T000, First product, 200.00, 20 " + p1);
            Console.WriteLine();
        }
        // Tests for customer
        static void TestCustomerConstructors()
        {
            //Test constructors
            Customer c1 = new Customer();
            Customer c2 = new Customer(101, "John", "Doe", "john.doe@example.com", "555-1234");

            Console.WriteLine("Testing Customer constructors");
            Console.WriteLine("Default constructor. Expecting default values. 0, , , ,  " + c1.ToString());
            Console.WriteLine("Overloaded constructor. Expecting 101, John, Doe, john.doe@example.com, 555-1234 " + c2.ToString());
            Console.WriteLine();
        }

        static void TestCustomerToString()
        {
            //Test toString
            Customer c1 = new Customer(101, "John", "Doe", "john.doe@example.com", "555-1234");

            Console.WriteLine("Testing Customer ToString");
            Console.WriteLine("Expecting 101, John, Doe, john.doe@example.com, 555-1234 " + c1.ToString());
            Console.WriteLine("Expecting 101, John, Doe, john.doe@example.com, 555-1234 " + c1);
            Console.WriteLine();
        }

        static void TestCustomerPropertyGetters()
        {
            //Test getters
            Customer c1 = new Customer(101, "John", "Doe", "john.doe@example.com", "555-1234");

            Console.WriteLine("Testing Customer getters");
            Console.WriteLine("Id. Expecting 101. " + c1.Id);
            Console.WriteLine("FirstName. Expecting John. " + c1.FirstName);
            Console.WriteLine("LastName. Expecting Doe. " + c1.LastName);
            Console.WriteLine("Email. Expecting john.doe@example.com. " + c1.Email);
            Console.WriteLine("Phone. Expecting 555-1234. " + c1.Phone);
            Console.WriteLine();
        }

        static void TestCustomerPropertySetters()
        {
            //Test setters
            Customer c1 = new Customer(101, "John", "Doe", "john.doe@example.com", "555-1234");

            Console.WriteLine("Testing Customer setters");
            c1.Id = 102;
            c1.FirstName = "Jane";
            c1.LastName = "Smith";
            c1.Email = "jane.smith@example.com";
            c1.Phone = "555-5678";
            Console.WriteLine("Expecting 102, Jane, Smith, jane.smith@example.com, 555-5678 " + c1);
            Console.WriteLine();
        }
    }
}
