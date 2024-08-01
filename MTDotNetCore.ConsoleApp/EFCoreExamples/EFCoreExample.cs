using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MTDotNetCore.ConsoleApp.Dtos;

namespace MTDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class EFCoreExample
    {
        // Use Microsoft.Extensions.DependencyInjection

        //private readonly AppDbContext db = new AppDbContext();

        private readonly AppDbContext db;

        public EFCoreExample(AppDbContext db)
        {
            this.db = db;
        }

        public void Run()
        {
            //Read();
            //Edit(10);
            //Edit(11);

            Create("new title", "new author", "new content");

            //Update(2006, "updated title", "updated author", "updated content");

            //Delete(1001);
            //Delete(2005);
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
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            db.Blogs.Add(item); // same as writing insert query
            int result = db.SaveChanges(); // same as Execute query

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            //item = db.Blogs.AsNoTracking().FirstOrDefault(x=> x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No data found with the Id:" + id);
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();

            string message = result > 0 ? "Update Successful" : "Update Failed";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No data found with the Id: " + id);
                return;
            }

            db.Blogs.Remove(item);
            int rowsAffected = db.SaveChanges();

            string message = rowsAffected > 0 ? "Delete Successful" : "Delete Failed";
            Console.WriteLine(message);
        }

        public void GenerateBlogData(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int rowNo = i + 1;
                Create("Title " + rowNo, "Author " + rowNo, "Content " + rowNo);
            }
        }
    }
}
