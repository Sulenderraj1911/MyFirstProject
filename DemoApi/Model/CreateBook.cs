namespace DemoApi.Model
{
    public class CreateBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NoOfPages { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Author { get; set; }

        // Foreign key for Language
        public int LanguageId { get; set; }

    }
}
