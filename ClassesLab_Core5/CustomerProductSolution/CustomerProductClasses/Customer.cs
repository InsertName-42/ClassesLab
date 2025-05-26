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

        public Customer(int customerId, string email, string firstName, string lastName, string phone)
        {
            id = customerId;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
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

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Customer other = (Customer)obj;
                return other.Id == Id &&
                       other.Email == Email &&
                       other.FirstName == FirstName &&
                       other.LastName == LastName &&
                       other.Phone == Phone;
            }
        }

        public override int GetHashCode()
        {
            return 13 + 7 * id.GetHashCode() +
                   7 * email.GetHashCode() +
                   7 * firstName.GetHashCode() +
                   7 * lastName.GetHashCode() +
                   7 * phone.GetHashCode();
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !c1.Equals(c2);
        }
    }
}