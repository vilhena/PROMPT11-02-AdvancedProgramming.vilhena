namespace Mod02_AdvProgramming.Data
{
    public class Customer
    {
        private string _CustomerID;
        private string _CompanyName;
        private string _Name;
        private string _ContactTitle;
        private string _Address;
        private string _City;
        private string _Region;
        private string _PostalCode;
        private string _Country;
        private string _Phone;
        private string _Fax;
        private Order[] _Orders;

        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        //public string CustomerID { get; set; }


        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string ContactTitle
        {
            get { return _ContactTitle; }
            set { _ContactTitle = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        public Order[] Orders
        {
            get { return _Orders; }
            set { _Orders = value; }
        }
    }
}