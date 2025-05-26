using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductClasses
{
    public class CustomerList
    {
        private List<Customer> customers;

        public CustomerList()
        {
            customers = new List<Customer>();
        }

        public int Count
        {
            get
            {
                return customers.Count;
            }
        }

        public void Fill()
        {
            customers = CustomerDB.GetCustomers();
        }

        public void Save()
        {
            CustomerDB.SaveCustomers(customers);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public void Add(int id, string email, string firstName, string lastName, string phone)
        {
            Customer c = new Customer(id, email, firstName, lastName, phone);
            customers.Add(c);
        }

        public void Remove(Customer customer)
        {
            customers.Remove(customer);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Customer c in customers)
            {
                output += c.ToString() + "\n";
            }
            return output;
        }

        public Customer this[int i]
        {
            get
            {
                return customers[i];
            }
            set
            {
                customers[i] = value;
            }
        }

        public Customer this[string email]
        {
            get
            {
                foreach (Customer c in customers)
                {
                    if (c.Email == email)
                        return c;
                }
                return null;
            }
        }

        public static CustomerList operator +(CustomerList cl, Customer c)
        {
            cl.Add(c);
            return cl;
        }

        public static CustomerList operator -(CustomerList cl, Customer c)
        {
            cl.Remove(c);
            return cl;
        }
    }
}