namespace UnpaidBillsApp.Web.Models
{
    public class Company
    {
        public string name;
        public string id;

        public Company(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}