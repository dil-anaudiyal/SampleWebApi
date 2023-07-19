namespace BookManager
{
    public class Book
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public long PublishedYear { get; set; }
    }
}
