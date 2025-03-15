namespace BookLibrary.Data
{
	public class Book
	{
		public int Id { get; set; }
		public required string Title { get; set; }
		public required string Author { get; set; }
		public required string Description { get; set; }
		public double? Rate { get; set; }
		public DateTime? DateStart { get; set; }
		public DateTime? DateRead { get; set; }
	}
}