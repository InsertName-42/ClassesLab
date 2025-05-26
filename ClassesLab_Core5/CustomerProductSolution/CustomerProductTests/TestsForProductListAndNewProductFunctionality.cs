using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomerProductClasses;

namespace CustomerProductListTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Screen size
            Console.SetWindowSize(120, 40);
            //All tests
            //Product
            TestProductListConstructor();
            TestProductListAdd();
            TestProductListSaveAndFill();
            TestProductListRemove();
            TestProductEquals();
            TestProductGetHashCode();
            TestProductEqualityOperator();
            TestProductInequalityOperator();
            TestProductListIndexer();

            Console.WriteLine("\n--------------------------------------------------\n");

            //Customer
            TestCustomerListConstructor();
            TestCustomerListAdd();
            TestCustomerListSaveAndFill();
            TestCustomerListRemove();
            TestCustomerEquals();
            TestCustomerGetHashCode();
            TestCustomerEqualityOperator();
            TestCustomerInequalityOperator();
            TestCustomerListIndexer();


            Console.ReadLine();
        }
        //Product tests
        static void TestProductListConstructor()
        {
            ProductList list = new ProductList();

            Console.WriteLine("Testing product list default constructor");
            Console.WriteLine("Count. Expecting 0. " + list.Count);
            Console.WriteLine("ToString. Expect an empty string. " + list.ToString());
            Console.WriteLine();
        }

        static void TestProductListAdd()
        {
            //Adding using + and Add
            ProductList list = new ProductList();
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p2 = new Product(2, "T200", "This is a test product 2", 200M, 20);

            Console.WriteLine("Testing product list add.");
            Console.WriteLine("BEFORE Count. Expecting 0. " + list.Count);
            list.Add(p1);
            Console.WriteLine("AFTER Add Count. Expecting 1. " + list.Count);
            Console.WriteLine("ToString. Expect one product " + list.ToString());
            list += p2;
            Console.WriteLine("AFTER Second Add Count. Expecting 2. " + list.Count);
            Console.WriteLine("ToString. Expect two products " + list.ToString());
            Console.WriteLine();
        }

        static void TestProductListSaveAndFill()
        {
            ProductList list = new ProductList();
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p2 = new Product(2, "T200", "This is a test product 2", 200M, 20);
            list.Add(p1);
            list += p2;
            list.Save();

            list = new ProductList();
            list.Fill();
            Console.WriteLine("Testing product list save and fill.");
            Console.WriteLine("After Fill Count. Expecting 2. " + list.Count);
            Console.WriteLine("ToString. Expect two products " + list.ToString());
            Console.WriteLine();
        }

        static void TestProductEquals()
        {
            //Reference the same object.
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p1Reference = p1;
            //Attribute values are all equal.
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing product equals.");
            Console.WriteLine("2 references to the same object. Expecting true. " + p1.Equals(p1Reference));
            Console.WriteLine("2 object that have the same properties should be equal. Expecting true. " + p1.Equals(p2));
            Console.WriteLine();

        }

        static void TestProductListRemove()
        {
            ProductList list = new ProductList();
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);

            list.Fill();
            Console.WriteLine("Testing product list remove.");
            Console.WriteLine("Before remove Count. Expecting 2. " + list.Count);
            Console.WriteLine("ToString. Expect two products " + list.ToString());
            list.Remove(p1);
            Console.WriteLine("After remove Count. Expecting 1. " + list.Count);
            Console.WriteLine("ToString. Expect just product 2 " + list.ToString());
            Console.WriteLine();
        }

        static void TestProductGetHashCode()
        {
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            //Attribute values are all equal.
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);
            //Unique hashcode
            Product p3 = new Product(3, "T300", "This is a test product 3", 300M, 30);

            Console.WriteLine("Testing product GetHashCode");
            Console.WriteLine("2 object that have the same properties should have the same hashcode. Expecting true. " + (p1.GetHashCode() == p2.GetHashCode()));
            Console.WriteLine("2 object that have different properties should have different hashcodes. Expecting false. " + (p1.GetHashCode() == p3.GetHashCode()));

            //Needs HashCode override
            HashSet<Product> set = new HashSet<Product>();
            set.Add(p1);
            set.Add(p3);
            Console.WriteLine("Testing product GetHashCode by using a hash set");
            Console.WriteLine("The hash set should be able to find an object with the same attributes. Expecting true. " + set.Contains(p2));

            Console.WriteLine();
        }

        static void TestProductEqualityOperator()
        {
            //Reference the same object.
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p1Reference = p1;
            //Attribute values are all equal.
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing product ==");
            Console.WriteLine("2 references to the same object. Expecting true. " + (p1 == p1Reference));
            Console.WriteLine("2 object that have the same properties should be equal. Expecting true. " + (p1 == p2));
            Console.WriteLine();
        }

        static void TestProductInequalityOperator()
        {
            //Attribute values are all equal.
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);
            //Not equal
            Product p3 = new Product(3, "T300", "This is a test product 3", 300M, 30);

            Console.WriteLine("Testing product !=");
            Console.WriteLine("2 objects that have the same properties should be equal. Expecting false. " + (p1 != p2));
            Console.WriteLine("2 objecst that have different properties should not be equal. Expecting true. " + (p1 != p3));
            Console.WriteLine();
        }

        static void TestProductListIndexer()
        {
            //Needs product equals
            ProductList list = new ProductList();
            list.Fill();

            Console.WriteLine("Testing product list indexer");
            Console.WriteLine("Index 1. Expecting first product in list to be T100 \n" + list[0]);
            Console.WriteLine("Index 'T200'. Expecting product with code of T200 \n" + list["T200"]);
            Console.WriteLine();
        }
        //Customer tests (equivilant function)
        static void TestCustomerListConstructor()
        {
            CustomerList list = new CustomerList();

            Console.WriteLine("Testing customer list default constructor");
            Console.WriteLine("Count. Expecting 0. " + list.Count);
            Console.WriteLine("ToString. Expect an empty string. " + list.ToString());
            Console.WriteLine();
        }

        static void TestCustomerListAdd()
        {
            CustomerList list = new CustomerList();
            Customer c1 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");
            Customer c2 = new Customer(2, "bob.johnson@example.com", "Bob", "Johnson", "555-333-4444");

            Console.WriteLine("Testing customer list add.");
            Console.WriteLine("BEFORE Count. Expecting 0. " + list.Count);
            list.Add(c1);
            Console.WriteLine("AFTER Add Count. Expecting 1. " + list.Count);
            Console.WriteLine("ToString. Expect one customer " + list.ToString());
            list += c2;
            Console.WriteLine("AFTER Second Add Count. Expecting 2. " + list.Count);
            Console.WriteLine("ToString. Expect two customers " + list.ToString());
            Console.WriteLine();
        }

        static void TestCustomerListSaveAndFill()
        {
            CustomerList list = new CustomerList();
            Customer c1 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");
            Customer c2 = new Customer(2, "bob.johnson@example.com", "Bob", "Johnson", "555-333-4444");
            list.Add(c1);
            list += c2;
            list.Save();

            list = new CustomerList();
            list.Fill();
            Console.WriteLine("Testing customer list save and fill.");
            Console.WriteLine("After Fill Count. Expecting 2. " + list.Count);
            Console.WriteLine("ToString. Expect two customers " + list.ToString());
            Console.WriteLine();
        }

        static void TestCustomerEquals()
        {
            //Reference the same object.
            Customer c1 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");
            Customer c1Reference = c1;
            //Attribute values are all equal.
            Customer c2 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");

            Console.WriteLine("Testing customer equals.");
            Console.WriteLine("2 references to the same object. Expecting true. " + c1.Equals(c1Reference));
            Console.WriteLine("2 objects that have the same properties should be equal. Expecting true. " + c1.Equals(c2));
            Console.WriteLine();

        }

        static void TestCustomerListRemove()
        {
            CustomerList list = new CustomerList();
            Customer c1 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");

            list.Fill();
            Console.WriteLine("Testing customer list remove.");
            Console.WriteLine("Before remove Count. Expecting 2. " + list.Count);
            Console.WriteLine("ToString. Expect two customers " + list.ToString());
            list.Remove(c1);
            Console.WriteLine("After remove Count. Expecting 1. " + list.Count);
            Console.WriteLine("ToString. Expect just customer 2 \n" + list.ToString());
            Console.WriteLine();
        }

        static void TestCustomerGetHashCode()
        {
            Customer c1 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");
            //Attribute values are all equal.
            Customer c2 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");
            //Unique hashcode
            Customer c3 = new Customer(3, "charlie.brown@example.com", "Charlie", "Brown", "555-555-5555");

            Console.WriteLine("Testing customer GetHashCode");
            Console.WriteLine("2 objects that have the same properties should have the same hashcode. Expecting true. " + (c1.GetHashCode() == c2.GetHashCode()));
            Console.WriteLine("2 objects that have different properties should have different hashcodes. Expecting false. " + (c1.GetHashCode() == c3.GetHashCode()));

            HashSet<Customer> set = new HashSet<Customer>();
            set.Add(c1);
            set.Add(c3);
            Console.WriteLine("Testing customer GetHashCode by using a hash set");
            Console.WriteLine("The hash set should be able to find an object with the same attributes. Expecting true. " + set.Contains(c2));
            Console.WriteLine();
        }

        static void TestCustomerEqualityOperator()
        {
            //Reference the same object.
            Customer c1 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");
            Customer c1Reference = c1;
            //Attribute values are all equal.
            Customer c2 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");

            Console.WriteLine("Testing customer ==");
            Console.WriteLine("2 references to the same object. Expecting true. " + (c1 == c1Reference));
            Console.WriteLine("2 objects that have the same properties should be equal. Expecting true. " + (c1 == c2));
            Console.WriteLine();
        }

        static void TestCustomerInequalityOperator()
        {
            //Attribute values are all equal.
            Customer c1 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");
            Customer c2 = new Customer(1, "alice.smith@example.com", "Alice", "Smith", "555-111-2222");
            Customer c3 = new Customer(3, "charlie.brown@example.com", "Charlie", "Brown", "555-555-5555");

            Console.WriteLine("Testing customer !=");
            Console.WriteLine("2 objects that have the same properties should be equal. Expecting false. " + (c1 != c2));
            Console.WriteLine("2 objects that have different properties should not be equal. Expecting true. " + (c1 != c3));
            Console.WriteLine();
        }

        static void TestCustomerListIndexer()
        {
            CustomerList list = new CustomerList();
            list.Fill();

            Console.WriteLine("Testing customer list indexer");
            Console.WriteLine("Index 0. Expecting first customer in list \n" + list[0]);
            Console.WriteLine("Index 'bob.johnson@example.com'. Expecting customer with email bob.johnson@example.com \n" + list["bob.johnson@example.com"]);
            Console.WriteLine();
        }
    }
}