using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                Console.WriteLine("Inserting a new Blog");
                db.Add(new Blog { Url = "http://something.com" });
                db.SaveChanges();

                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs.OrderBy(b => b.BlogId)
                    .First();
                Console.WriteLine(blog.BlogId);

                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "http://somethingelse.com";
                blog.Posts.Add(new Post { Title = "Hello world", Content = "First post content." });
                db.SaveChanges();

                Console.WriteLine("Deleting the blog");
                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}
