using Bibblan.Models;

namespace Bibblan.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed Books
            var books = new List<Book>
            {
                new Book { BookName = "Dune", BookDescription = "A book about sand", BookAuthor = "Frank Herbert" },
                new Book { BookName = "Dune: Messiah", BookDescription = "A book about more sand, and space jesus", BookAuthor = "Frank Herbert" },
                new Book { BookName = "Dune: Children of Dune", BookDescription = "Sand and space jesus' kids", BookAuthor = "Frank Herbert" },
                new Book { BookName = "Leviathan Wakes", BookDescription = "Teambuilding session turns into space war", BookAuthor = "James S.A. Corey" },
                new Book { BookName = "The Name of the Wind", BookDescription = "Daemon spiders and sympathetic wizards or something", BookAuthor = "Patrick Rothfuss" },
                new Book { BookName = "The Fellowship of the Ring", BookDescription = "What to do with your old jewelry", BookAuthor = "J.R.R. Tolkien" }
            };

            context.Books.AddRange(books);
            context.SaveChanges();

            // Seed Customers
            var customers = new List<Customer>
            {
                new Customer { CustomerName = "John Doe", CustomerEmail = "john@example.com", CustomerPhone = "123456789", CustomerAddress = "123 Main St" },
                new Customer { CustomerName = "Jane Smith", CustomerEmail = "jane@example.com", CustomerPhone = "987654321", CustomerAddress = "456 Elm St" }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();

            // Seed BookCheckouts (optional)
            var bookCheckouts = new List<BookCheckout>
            {
                new BookCheckout { FkCustomerId = 1, FkBookId = 1, DateCreated = DateTime.Now.AddDays(-10), IsReturned = false },
                new BookCheckout { FkCustomerId = 2, FkBookId = 2, DateCreated = DateTime.Now.AddDays(-5), IsReturned = true }
            };

            context.BookCheckouts.AddRange(bookCheckouts);
            context.SaveChanges();
        }
    }
}
