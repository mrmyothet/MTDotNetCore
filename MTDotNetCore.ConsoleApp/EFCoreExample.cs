using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDotNetCore.ConsoleApp
{
    internal class EFCoreExample
    {

        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            Read();
            Edit(10);
            Edit(11);
        }

        private void Read()
        {
            var lstBlogs = db.Blogs.ToList();

            // ERROR 
            // Microsoft.Data.SqlClient.SqlException:
            // 'A connection was successfully established with the server, but then an error occurred during the login process.
            // (provider: SSL Provider, error: 0 - The certificate chain was issued by an authority that is not trusted.)'

            // Fix 
            // Add TrustServerCertificate = true in connection string 


            foreach (BlogDto item in lstBlogs)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("------------------------------");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x=> x.BlogId == id);

            if (item is null) {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }
    }
}
