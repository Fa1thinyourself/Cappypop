namespace CappypopMVC.Models.Viewmodel
{
	public class CartItem
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public string Image { get; set; } = "";
		public double Price { get; set; } = 0;
		public int Quantity { get; set; } = 0;
		public string Size { get; set; } = "";
		public string Sugar { get; set; } = "";
		public string Ice { get; set; } = "";
		public string Topping { get; set; } = "";
		public double Total => Price * Quantity;
	}
}