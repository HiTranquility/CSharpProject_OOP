namespace LibraryManagement.Model
{
    internal class Book
    {
        private string id;
        private string title;
        private string author;
        private string genre;
        private bool isAvailable;
        private DateTime publicationDate;
        private string borrowerId;

        public string Id { get { return id; } set { this.id = value; } }
        public string Title { get { return title; } set { this.title = value; } }
        public string Author { get { return author; } set { this.author = value; } }
        public string Genre { get { return genre; } set { this.genre = value; } }
        public bool IsAvailable { get { return isAvailable; } set { this.isAvailable = value; } }
        public DateTime PublicationDate { get { return publicationDate; } set { this.publicationDate = value; } }
        public string BorrowerId { get { return borrowerId; } set { this.borrowerId = value; } } 

        // Constructor
        public Book(string title, string author, string genre, bool isAvailable, DateTime publicationDate)
        {
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.isAvailable = isAvailable;
            this.publicationDate = publicationDate;
            this.borrowerId = null;
        }

        // Default Constructor
        public Book()
        {
            this.borrowerId = null;
        }

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Title: {Title}\n" +
                   $"Author: {Author}\n" +
                   $"Genre: {Genre}\n" +
                   $"Available: {(IsAvailable ? "Yes" : "No")}\n" +
                   $"Borrower ID: {BorrowerId ?? "None"}\n" +
                   $"Publication Date: {PublicationDate:yyyy-MM-dd}\n";
        }
    }
}
