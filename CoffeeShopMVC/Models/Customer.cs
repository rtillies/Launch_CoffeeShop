namespace CoffeeShopMVC.Models
{
	public class Customer
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public double TotalSpend()
        {
            double total = 0.0;
            foreach (var order in Orders)
            {
                total += order.OrderTotal();
            }
            return total;
        }

        public string DisplayDollars(int cents)
        {
			return Math.Round(cents / 100.0, 2).ToString();
		}

		public string DisplayDollars()
		{
			return Math.Round(TotalSpend() / 100.0, 2).ToString();
		}

	}
}
