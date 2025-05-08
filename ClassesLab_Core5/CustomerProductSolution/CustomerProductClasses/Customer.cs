using System;

namespace CustomerProductClasses
{
    public class Customer
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;

        public Customer() { }

        public Customer(int customerId, string firstName, string lastName, string email, string phone)
        {
            id = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public override string ToString()
        {
            return String.Format("Id: {0} FirstName: {1} LastName: {2} Email: {3} Phone: {4}", id, firstName, lastName, email, phone);
        }
    }
}