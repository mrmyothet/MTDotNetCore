﻿namespace MTDotNetCore.RestApiWithNLayer.Models;


[Table("Tbl_Blog")]
public class BlogModel
{
    [Key]
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}

//public record BlogIdentity(int Blogid, string BlogTitle, string BlogAuthor, string BlogContent);
