// The following code creates a database on-the-fly.
// This is useful only in limited scenarios including demos.
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{    
    context.Database.EnsureCreated();
}

//GetAuthors();
//AddAuthor();
//GetAuthors();
AddAuthorWithBook();
GetAuthorWithBooks();

void AddAuthorWithBook()
{
    var author = new Author
    {
        FirstName = "William",
        LastName = "Shakespeare"
    };

    author.Books.Add(new Book
    {
        Title = "Romeo and Juliet",
        PublishDate = new DateOnly(1597, 1, 1)
    });

    author.Books.Add(new Book
    {
        Title = "Hamlet",
        PublishDate = new DateOnly(1603, 1, 1)
    });

   
    using (var context = new PubContext())
    {
        context.Authors.Add(author);
        context.SaveChanges();
    }
}

void GetAuthorWithBooks()
{
    using (var context = new PubContext())
    {
        var authors = context.Authors
            .Include(a => a.Books)
            .ToList();

        foreach (var author in authors)
        {
            Console.WriteLine($"{author.FirstName} {author.LastName}");
            foreach (var book in author.Books)
            {
                Console.WriteLine($"{book.Title} {book.PublishDate}");
            }

        }        
    }
}

void AddAuthor()
{
    var author = new Author
    {
        FirstName = "William",
        LastName = "Shakespeare"
    };

    using (var context = new PubContext())
    {        
        context.Authors.Add(author);
        context.SaveChanges();
    }
}

void GetAuthors()
{
    using (var context = new PubContext())
    {        
        var authors = context.Authors.ToList();
        foreach (var author in authors)
        {
            Console.WriteLine($"{author.FirstName} {author.LastName}");
        }
    }
}