namespace CoffeeShopMVC.Models
{
	public class Order
	{
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public Customer Customer { get; set; }

        public double OrderTotal()
        {
            double total = 0.0;
            foreach(var item in Items)
            {
                total += item.PriceInCents;
            }
            return total;
        }

		public string DisplayDollars(int cents)
		{
			return Math.Round(cents / 100.0, 2).ToString();
		}

	}
}
