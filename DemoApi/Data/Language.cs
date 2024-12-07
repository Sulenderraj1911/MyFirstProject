namespace DemoApi.Data
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation property for related Books
        public ICollection<Book> Books { get; set; }
      

    }
}
